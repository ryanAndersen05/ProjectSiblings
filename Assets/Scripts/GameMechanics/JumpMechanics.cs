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
        if (!checkInAir.inAir || Mathf.Abs(mMechanics.getCurrentHInput()) < 0.01f) return;
        
        float xVel = rigid.velocity.x;
        //print(xVel);
        xVel = Mathf.MoveTowards(xVel, mMechanics.getCurrentHInput() / Mathf.Abs(mMechanics.getCurrentHInput()) * movementInAirSpeed, movementAcceleration * Time.fixedDeltaTime);
        //print(xVel);
        rigid.velocity = new Vector2(xVel, rigid.velocity.y);
    }

    public bool activateJump(bool jumpInput)
    {
        if (jumpDisabled) return false;
        if (jumpInput && !checkInAir.inAir)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            return true;
        }
        return false;
    }
}
