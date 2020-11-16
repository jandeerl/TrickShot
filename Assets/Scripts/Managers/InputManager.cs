using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private bool _isUsingMouse = true;

    public LineCoordinates LineCoordinates { get; set; }
    public EventPublisher OnPressingDown { get; set; }
    public EventPublisher OnReleaseInput { get; set; }

    private Camera _mainCamera;
    private Action _onClicked;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (PressingDown)
        {
            SetLineCoordinates();
            RegisterClick();
            OnPressingDown.Notify();

        }
        else
            ClickReleased();
    }

    private bool PressingDown
    {
        get
        {
            if (_isUsingMouse)
            {
                return Input.GetMouseButton(0);
            }
            else
                return Input.touchCount > 0;
        }
    }

    private void RegisterClick()
    {
        if (_onClicked == null)
            _onClicked += OnReleaseInput.Notify;
    }

    private void ClickReleased()
    {
        _onClicked?.Invoke();
        if (_onClicked != null)
            _onClicked -= OnReleaseInput.Notify;
    }

    private void SetLineCoordinates()
    {
        LineCoordinates.startingPosition = InitialTouchPosition;
        LineCoordinates.endPosition = CurrentCursorPosition;
    }

    private Vector2 InitialTouchPosition
    {
        get
        {
            if (Input.GetMouseButtonDown(0))
                return _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                return _mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
            else
                return LineCoordinates.startingPosition;
        }
    }

    private Vector2 CurrentCursorPosition
    {
        get
        {
            if (_isUsingMouse)
                return _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            else
                return _mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
    }
}
