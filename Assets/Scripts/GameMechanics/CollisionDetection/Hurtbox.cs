using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Hurtbox : MonoBehaviour {
    public Transform parentObject;
    public Health health;

    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        parentObject = this.transform;
        while(parentObject.parent != null)
        {
            parentObject = parentObject.parent;
        }
        health = parentObject.GetComponent<Health>();
    }    
}
