using UnityEngine;
using System.Collections;

public class CheckInAir : MonoBehaviour {
    public bool inAir = false;
    public bool lockInAir = false;
    public float checkDistance = .01f;
    public string[] ignoreLayers = new string[0];
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
        if (lockInAir) return;
        checkInAir();
    }

    void checkInAir()
    {
        inAir = true;
        foreach(Transform t in checkPositions)
        {
            RaycastHit2D hit;
            Ray2D r = new Ray2D(t.position, Vector2.down);
            int layerMask = -1;
            foreach (string l in ignoreLayers)
            {
                layerMask -= 1 << LayerMask.NameToLayer(l);
            }
            hit = Physics2D.Raycast(r.origin, r.direction, checkDistance, layerMask);
            if (hit)
            {
                //print(hit.transform.name);
                inAir = false;
                return;
            }

        }
    }
}
