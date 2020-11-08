using UnityEngine;


public class AimingLine : MonoBehaviour, IEventSubscriber
{
    [SerializeField, Range(0.5f, 2f)]
    private float maxLineLength = 1f;
    [SerializeField]
    private EventPublisher onPressingDown;
    [SerializeField]
    private EventPublisher onReleaseInput;
    [SerializeField]
    LineCoordinates lineCoordinates;

    private LineRenderer line;

    private void Awake()
    {
        line = gameObject.GetComponent<LineRenderer>();
        onPressingDown.Subscribe(this);
        onReleaseInput.Subscribe(this);
    }

    void IEventSubscriber.PerformUpdate(IEventPublisher publisher)
    {
        if ((Object)publisher == onPressingDown)
        {
            ClampLineLength();
            DrawLineToFinger();
        }
        if ((Object)publisher == onReleaseInput)
            HideLineRenderer();
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

        //make the line wider the longer it is    
        line.endWidth = DistanceFromInitialTouch;
        line.enabled = true;
    }


    private float DistanceFromInitialTouch => 
        (lineCoordinates.endPosition - lineCoordinates.startingPosition).magnitude;
    private void HideLineRenderer() => 
        line.enabled = false;


}
