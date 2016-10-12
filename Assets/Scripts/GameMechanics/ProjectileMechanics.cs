using UnityEngine;
using System.Collections;

public class ProjectileMechanics : MonoBehaviour {
    public float maxLaunchForce = 10;
    public float launchDirection = 0;
    public bool updatePhysics;
    float launchSpeed;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        this.launchSpeed = maxLaunchForce;
        launchArrow();
    }

    void Update()
    {
        float x = rigid.velocity.x;
        float y = rigid.velocity.y;

        float direction = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, direction);
    }

    public void setUpLaunch(float launchSpeed, float launchDirection)
    {
        this.launchSpeed = launchSpeed;
        this.launchDirection = launchDirection;
    }

    public void launchArrow()
    {
        transform.rotation = Quaternion.Euler(0, 0, launchDirection);
        rigid.AddForce(transform.right * maxLaunchForce, ForceMode2D.Impulse);

    }
}
