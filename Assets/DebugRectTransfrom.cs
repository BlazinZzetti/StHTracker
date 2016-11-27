using UnityEngine;
using System.Collections;

public class DebugRectTransfrom : MonoBehaviour
{
    public float rectX;
    public float rectY;
    public float rectWidth;
    public float rectHeight;

    public float offsetMinX;
    public float offsetMinY;

    public float offsetMaxX;
    public float offsetMaxY;

    public float sizeDeltaX;
    public float sizeDeltaY;

    // Update is called once per frame
    void Update ()
    {
        ((RectTransform)transform).rect.Set(0,0,0,0);
	}
}
