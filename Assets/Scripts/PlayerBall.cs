using UnityEngine;

public class PlayerBall : MonoBehaviour, IEventSubscriber
{
    [SerializeField]
    private float pushForce = 2f;
    [SerializeField]
    private LineCoordinates LineCoordinates;
    [SerializeField]
    private EventPublisher onReleaseInput;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        onReleaseInput.Subscribe(this);
    }

    public void PerformUpdate(IEventPublisher publisher)
    {
        ShootBall();
    }

    private void ShootBall()
    {
       rb.AddForce(ShootingDirection * pushForce * 10);
    }

    private Vector2 ShootingDirection =>
        -(LineCoordinates.endPosition - LineCoordinates.startingPosition);
}
