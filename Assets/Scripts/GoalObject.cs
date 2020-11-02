using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObject : MonoBehaviour
{
    [SerializeField]
    private Vector2[] positions;

    [ContextMenu("Test")]
    public void MoveToRandomPosition()
    {
        int num;
        do 
        {num = Random.Range(0, positions.Length);}
        while 
        ((Vector2)transform.position == positions[num]);

        transform.position = positions[num];
    }
}
