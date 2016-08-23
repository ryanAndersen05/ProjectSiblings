using UnityEngine;
using System.Collections;

public class CheckInAir : MonoBehaviour {
    public bool inAir = false;
    public bool lockInAir = false;
    public float checkDistance = .01f;
    public Transform[] checkPositions = new Transform[3];
    Animator anim;

    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    void Update()
    {
        if (anim != null)
        {
            anim.SetBool("InAir", inAir);
        }
    }

    void FixedUpdate()
    {
        if (lockInAir) return;
        checkInAir();
    }

    void checkInAir()
    {
        inAir = true;
        foreach(Transform t in checkPositions)
        {
            Ray2D r = new Ray2D(t.position, Vector2.down);
            if (Physics2D.Raycast(r.origin, r.direction, checkDistance))
            {
                inAir = false;
                return;
            }

        }
    }
}
