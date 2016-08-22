using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class CustomGravity : MonoBehaviour {
    public float gravityScale = 1;
    public float maxFallingSpeed = 10f;

    public const float gravityForce = 9.8f;
    Rigidbody2D rigid;

    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float y = rigid.velocity.y;
        y = Mathf.MoveTowards(y, -maxFallingSpeed, Time.fixedDeltaTime * gravityForce * gravityScale);
        rigid.velocity = new Vector2(rigid.velocity.x, y);
    }

}
