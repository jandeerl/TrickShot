using System;
using UnityEngine;

public class GoalObject : MonoBehaviour
{
    [SerializeField]
    private Vector2[] positions;

    public void MoveToRandomPosition()
    {
        transform.position = RandomPositionFromArray(transform.position);
    }

    private Vector2 RandomPositionFromArray(Vector2 currentPosition)
    {
        if(currentPosition != positions[0])
        {
            return positions[0];
        }
        else
        {
            Array.Reverse(positions);
            int random = UnityEngine.Random.Range(0, positions.Length - 1);
            return positions[random];
        }
    }
}
