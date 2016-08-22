using UnityEngine;
using System.Collections;

public class JumpMechanics : MonoBehaviour {
    public float jumpForce = 15;
    CheckInAir checkInAir;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        checkInAir = GetComponentInChildren<CheckInAir>();
    }

    public void activateJump(bool jumpInput)
    {
        if (jumpInput && !checkInAir.inAir)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
