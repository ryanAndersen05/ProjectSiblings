using UnityEngine;
using System.Collections;

public class ProjectileMechanics : MonoBehaviour {
    public float maxLaunchForce = 10;
    public float launchDirection = 0;
    public bool updatePhysics;
    public float disableDistance = 25;
    float launchSpeed;
    Rigidbody2D rigid;
    Vector3 launchPosition;

    void Awake()
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

        if ((launchPosition - transform.position).magnitude > disableDistance)
        {
            this.gameObject.SetActive(false);
            rigid.isKinematic = true;
        }
    }

    public void setUpLaunch(float launchSpeed, float launchDirection)
    {
        this.launchSpeed = launchSpeed;
        this.launchDirection = launchDirection;
    }

    public void launchArrow()
    {
        rigid.gravityScale = Mathf.Abs(1 - launchSpeed / maxLaunchForce);
        rigid.isKinematic = false;
        launchPosition = transform.position;
        transform.rotation = Quaternion.Euler(0, 0, launchDirection);
        
        rigid.AddForce(transform.right * launchSpeed, ForceMode2D.Impulse);

    }
}
