using UnityEngine;
using System.Collections;

public class CustomGravity : MonoBehaviour {
    public const float GRAVITY = 9.8f;
    public const float maxFallingSpeed = 25;
    public float gravityScale = 1;
    public float fastFallScale = 2f;
    public float slowFallScale = .60f;

    CheckInAir checkInAir;
    Rigidbody2D rigid;

    void Start()
    {
        checkInAir = GetComponentInChildren<CheckInAir>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (checkInAir != null && !checkInAir.inAir) return;
        float y = rigid.velocity.y;
        y = Mathf.MoveTowards(y, -maxFallingSpeed, Time.fixedDeltaTime * gravityScale * GRAVITY);
        rigid.velocity = new Vector2(rigid.velocity.x, y);

    }
}
