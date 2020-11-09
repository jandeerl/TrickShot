using UnityEngine;

public class MaintainScreenWidth : MonoBehaviour
{
    [SerializeField]
    private float desiredWidth = 10;

    float unitsPerPixel, desiredHalfHeight;
    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();

        unitsPerPixel = desiredWidth / Screen.width;

        desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        cam.orthographicSize = desiredHalfHeight;
    }
}
