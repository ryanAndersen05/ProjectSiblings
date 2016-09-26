using UnityEngine;
using System.Collections;

public class OptionsPointer : MonoBehaviour {
    public RectTransform destination;
    public float pointerSpeed = 10;

    void Start()
    {
        setPosition();
    }

    void Update()
    {
        if (destination == null) return;
        this.transform.position = Vector3.Lerp(this.transform.position, destination.position, pointerSpeed * Time.deltaTime);
    }

    public void setPosition()
    {
        if (destination == null) return;
        this.transform.position = destination.position;
    }
}
