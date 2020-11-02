using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    [SerializeField]
    private float pushForce = 2f;
    [SerializeField]
    private LineCoordinates LineCoordinates;
    [SerializeField]
    private OnPressingDownEvent OnPressingDown;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        OnPressingDown.onReleased += ShootBall;
    }

    private void OnDisable()
    {
        OnPressingDown.onReleased -= ShootBall;
    }

    private void ShootBall()
    {
       rb.AddForce(ShootingDirection * pushForce * 10);
    }

    private Vector2 ShootingDirection => -(LineCoordinates.endPosition - LineCoordinates.startingPosition);
}
