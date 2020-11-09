using UnityEngine;

[CreateAssetMenu(fileName = "LineCoordinates_Object", menuName = "Scriptable Objects/Line Coordinates")]
public class LineCoordinates : ScriptableObject
{
    private Vector2 startingPos;
    private Vector2 endPos;

    public Vector2 startingPosition
    {
        get { return startingPos; }
        set { startingPos = value; }
    }

    public Vector2 endPosition
    {
        get { return endPos; }
        set { endPos = value; }
    }
}
