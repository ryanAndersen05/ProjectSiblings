using UnityEngine;
using System.Collections;

public class MovementMechanics : MonoBehaviour {
    public float walkSpeed = 3;
    public float runSpeed = 5;
    public float acceleration = 3;
    public bool updateSpeed = true;
    public bool updateInput = true;

    float currentSpeed = 0;
    float hInput;
    Rigidbody2D rigid;
    FlipSprite fSprite;
    Animator anim;
    CheckInAir checkInAir;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        checkInAir = GetComponentInChildren<CheckInAir>();
        fSprite = GetComponent<FlipSprite>();
    }

    
    void FixedUpdate()
    {
        if (!updateSpeed || checkInAir.inAir)
        {
            return;
        }
        if (!updateInput) hInput = 0;
        float goalSpeed = 0;
        if (Mathf.Abs(hInput) > 0.5f)
        {
            if (hInput > 0)
            {
                goalSpeed = runSpeed;
            }
            else
            {
                goalSpeed = -runSpeed;
            }
        }
        else if (Mathf.Abs(hInput) > 0.01f)
        {
            if (hInput > 0)
            {
                goalSpeed = walkSpeed;
            }
            else
            {
                goalSpeed = -walkSpeed;
            }
        }
        currentSpeed = Mathf.MoveTowards(rigid.velocity.x, goalSpeed, Time.fixedDeltaTime * acceleration);
        rigid.velocity = new Vector2(currentSpeed, rigid.velocity.y);
        //print(rigid.velocity);
    }

    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(hInput));
        if (hInput < 0)
        {
            fSprite.isRight = false;
        }
        else if (hInput > 0)
        {
            fSprite.isRight = true;
        }
    }

    /// <summary>
    /// Sets the horizontal input received from a controller class. Should be a number between 1 and -1 inclusive
    /// </summary>
    /// <param name="hInput"></param>
    public void setHorizontalInput(float hInput)
    {
        if (Mathf.Abs(hInput) > 1)
        {
            hInput = hInput / Mathf.Abs(hInput);
        }
        this.hInput = hInput;
    }

    public float getCurrentHInput()
    {
        return hInput;
    }
}
