using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private bool isUsingMouse = false;
    [SerializeField]
    private LineCoordinates lineCoordinates;
    [SerializeField]
    private EventPublisher onPressingDown;
    [SerializeField]
    private EventPublisher onReleaseInput;

    private Camera mainCamera;
    private Action onClicked;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (PressingDown)
        {
            SetLineCoordinates();
            RegisterClick();
            onPressingDown.Notify();

        }
        else
        {
            ClickReleased();
        }
    }

    private bool PressingDown
    {
        get
        {
            if (isUsingMouse)
            {
                return Input.GetMouseButton(0);
            }
            else
                return Input.touchCount > 0;
        }
    }

    private void RegisterClick()
    {
        if (onClicked == null)
            onClicked += onReleaseInput.Notify;
    }

    private void ClickReleased()
    {
        onClicked?.Invoke();
        if (onClicked != null)
            onClicked -= onReleaseInput.Notify;
    }

    private void SetLineCoordinates()
    {
        lineCoordinates.startingPosition = InitialTouchPosition;
        lineCoordinates.endPosition = CurrentCursorPosition;
    }

    private Vector2 InitialTouchPosition
    {
        get
        {
            if (Input.GetMouseButtonDown(0))
                return mainCamera.ScreenToWorldPoint(Input.mousePosition);
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                return mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
            else
                return lineCoordinates.startingPosition;
        }
    }

    private Vector2 CurrentCursorPosition
    {
        get
        {
            if (isUsingMouse)
                return mainCamera.ScreenToWorldPoint(Input.mousePosition);
            else
                return mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
    }
}
