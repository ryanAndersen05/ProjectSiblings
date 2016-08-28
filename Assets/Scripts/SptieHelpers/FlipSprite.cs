using UnityEngine;
using System.Collections;

public class FlipSprite : MonoBehaviour {
    public bool isRight = false;
    public bool lockDirection = false;

    void Start()
    {
        updateDirection();
    }

    void Update()
    {
        if (lockDirection)
        {
            return;
        }
        updateDirection();
    }

    public void updateDirection()
    {
       
        if (isRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
}
