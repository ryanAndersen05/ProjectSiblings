using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public float acceleration = 5;
    public float maxXOffset = float.PositiveInfinity;
    public float maxYOffset = float.PositiveInfinity;
    private float xOffset;
    private float yOffset;
    

    Transform currentTarget;


    void Start()
    {
        yOffset = transform.localPosition.y;
        xOffset = transform.localPosition.x;
        currentTarget = transform.parent;
        transform.parent = null;

    }

    void Update()
    {
        Vector3 goalPosition = new Vector3(currentTarget.position.x + xOffset,
            currentTarget.position.y + yOffset, transform.position.z);
        transform.position = Vector3.LerpUnclamped(transform.position, goalPosition, Time.deltaTime * acceleration);
        if (Mathf.Abs(transform.position.y - currentTarget.position.y) > maxYOffset)
        {
            transform.position = new Vector3(transform.position.x, currentTarget.position.y + maxYOffset, transform.position.z);
        }
    }
}
