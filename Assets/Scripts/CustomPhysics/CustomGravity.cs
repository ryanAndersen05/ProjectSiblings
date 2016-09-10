using UnityEngine;
using System.Collections;

public class CustomGravity : MonoBehaviour {
    public const float GRAVITY = 9.8f;
    public const float maxFallingSpeed = 25;
    public float gravityScale = 1;
    public float fastFallScale = 2f;
    public float slowFallScale = .60f;
    public bool gravityControl = true;

    float currentScale;
    float vInput;
    CheckInAir checkInAir;
    Rigidbody2D rigid;

    void Start()
    {
        currentScale = gravityScale;
        checkInAir = GetComponentInChildren<CheckInAir>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (checkInAir != null && !checkInAir.inAir) return;
        setCurrentScale();
        float y = rigid.velocity.y;
        y = Mathf.MoveTowards(y, -maxFallingSpeed, Time.fixedDeltaTime * currentScale * GRAVITY);
        rigid.velocity = new Vector2(rigid.velocity.x, y);
    }


    void setCurrentScale()
    {
        if (!gravityControl) return;
        if (vInput < -.3f)
        {
            currentScale = fastFallScale;
        }
        else if (vInput > .3f)
        {
            currentScale = slowFallScale;
        }
        else
        {
            currentScale = gravityScale;
        }

    }

    public void setVerticalInput(float vInput)
    {
        this.vInput = vInput;
    }
}
