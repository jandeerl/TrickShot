using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LineCoordinates_Object", menuName = "ScriptableObjects/Line Coordinates")]
public class LineCoordinates : ScriptableObject
{
    private Vector2 _startingPos;
    private Vector2 _endPos;

    public Vector2 startingPosition
    {
        get { return _startingPos; }
        set { _startingPos = value; }
    }

    public Vector2 endPosition
    {
        get { return _endPos; }
        set { _endPos = value; }
    }
}
