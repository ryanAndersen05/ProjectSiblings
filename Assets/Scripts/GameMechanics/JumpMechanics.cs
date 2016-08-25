using UnityEngine;
using System.Collections;

public class JumpMechanics : MonoBehaviour {
    public float jumpForce = 15;
    public bool jumpDisabled = false;
    public float movementInAirSpeed = 6;
    public float movementAcceleration = 12;
    CheckInAir checkInAir;
    Rigidbody2D rigid;
    MovementMechanics mMechanics;
    Animator anim;



    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        checkInAir = GetComponentInChildren<CheckInAir>();
        anim = GetComponent<Animator>();
        mMechanics = GetComponent<MovementMechanics>();
    }

    void Update()
    {
        if (anim != null)
        {
            anim.SetFloat("FallingVelocity", rigid.velocity.y);
        }
        
    }

    void FixedUpdate()
    {
        if (!checkInAir.inAir) return;
        
        float xVel = rigid.velocity.x;
        //print(xVel);
        xVel = Mathf.MoveTowards(xVel, mMechanics.getCurrentHInput() * movementInAirSpeed, movementAcceleration * Time.fixedDeltaTime);
        //print(xVel);
        rigid.velocity = new Vector2(xVel, rigid.velocity.y);
    }

    public void activateJump(bool jumpInput)
    {
        if (jumpDisabled) return;
        if (jumpInput && !checkInAir.inAir)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
