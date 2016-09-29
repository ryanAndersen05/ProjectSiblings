using UnityEngine;
using System.Collections;

public class FlipSprite : MonoBehaviour {
    public bool isRight = false;
    public bool lockDirection = false;
    public bool useScale = true;
    bool previousIsRight = false;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        updateDirection();

    }

    void Update()
    {
        if (lockDirection)
        {
            isRight = previousIsRight;
            return;
        }
        previousIsRight = isRight;
        updateDirection();

    }

    public void updateDirection()
    {
       
        if (isRight)
        {
            if (useScale)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            if (useScale)
            {
                transform.localScale = Vector3.one;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            
        }
    }
}
