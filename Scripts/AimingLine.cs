using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingLine : MonoBehaviour, IEventSubscriber
{
    [SerializeField, Range(0.5f, 2f)]
    private float maxLineLength = 1f;
    [SerializeField]
    private OnPressingDownEvent pressingDownEvent;
    [SerializeField]
    LineCoordinates lineCoordinates;

    private LineRenderer line;

    private void Awake()
    {
        line = gameObject.GetComponent<LineRenderer>();
        pressingDownEvent.Subscribe(this);
    }
    
    private void OnEnable()
    {
        pressingDownEvent.onReleased += HideLineRenderer;
    }
    
    private void OnDisable()
    {
        pressingDownEvent.onReleased -= HideLineRenderer;
    }

    void IEventSubscriber.PerformUpdate(IEventPublisher publisher)
    {
        ClampLineLength();
        DrawLineToFinger();
    }

    private void ClampLineLength()
    {
        Vector2 offset = lineCoordinates.endPosition - lineCoordinates.startingPosition;

        //ensures that the endpoint can only be drawn around a circle from starting position
        lineCoordinates.endPosition = Vector2.ClampMagnitude(offset, maxLineLength)
            + lineCoordinates.startingPosition;

    }



    private void DrawLineToFinger()
    {
        line.SetPosition(0, lineCoordinates.startingPosition);

        line.SetPosition(line.positionCount - 1, lineCoordinates.endPosition);

        //make the line wider the longer the line      
        line.endWidth = DistanceFromInitialTouch;
        line.enabled = true;
    }


    private float DistanceFromInitialTouch => 
        (lineCoordinates.endPosition - lineCoordinates.startingPosition).magnitude;
    private void HideLineRenderer() => 
        line.enabled = false;


}
