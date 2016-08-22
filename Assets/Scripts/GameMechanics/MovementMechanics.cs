using UnityEngine;
using System.Collections;

public class MovementMechanics : MonoBehaviour {
    public float maxSpeed = 1;
    public float acceleration = 3;
    public bool updateSpeed = true;

    float currentSpeed = 0;
    float hInput;
    Rigidbody2D rigid;
    Animator anim;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    
    void FixedUpdate()
    {
        if (!updateSpeed)
        {
            return;
        }
        currentSpeed = Mathf.MoveTowards(rigid.velocity.x, hInput * maxSpeed, Time.fixedDeltaTime * acceleration);
        rigid.velocity = new Vector2(currentSpeed, rigid.velocity.y);
    }

    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(hInput));
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
