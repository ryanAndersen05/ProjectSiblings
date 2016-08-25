using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public float xOffset;
    public float yOffset;
    public float acceleration = 5;

    Transform currentTarget;


    void Start()
    {
        currentTarget = transform.parent;
        transform.parent = null;
    }

    void Update()
    {
        Vector3 goalPosition = new Vector3(currentTarget.position.x + xOffset,
            currentTarget.position.y + yOffset, transform.position.z);
        transform.position = Vector3.LerpUnclamped(transform.position, goalPosition, Time.deltaTime * acceleration);
    }
}
