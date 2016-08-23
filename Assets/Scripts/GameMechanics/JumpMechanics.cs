using UnityEngine;
using System.Collections;

public class JumpMechanics : MonoBehaviour {
    public float jumpForce = 15;
    public bool jumpDisabled = false;
    CheckInAir checkInAir;
    Rigidbody2D rigid;
    Animator anim;



    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        checkInAir = GetComponentInChildren<CheckInAir>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (anim != null)
        {
            anim.SetFloat("FallingVelocity", rigid.velocity.y);
        }
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
