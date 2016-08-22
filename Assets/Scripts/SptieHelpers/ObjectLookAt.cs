using UnityEngine;
using System.Collections;

public class ObjectLookAt : MonoBehaviour {
    Transform cameraPosition;

    void Start()
    {
        cameraPosition = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        transform.LookAt(cameraPosition.position, Vector2.up);
    }
}
