using UnityEngine;
using System.Collections;

public class FlipSprite : MonoBehaviour {
    public bool isRight = false;
    public bool lockDirection = false;
    MovementMechanics mMechanics;

    void Start()
    {
        mMechanics = GetComponent<MovementMechanics>();
        updateDirection();
    }

    void Update()
    {
        if (lockDirection)
        {
            return;
        }
        float hInput = mMechanics.getCurrentHInput();
        if (Mathf.Abs(hInput) < .01f) {
            return;
        }
        if (hInput < 0)
        {
            isRight = false;
        }
        else
        {
            isRight = true;
        }
        updateDirection();
    }

    void updateDirection()
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
