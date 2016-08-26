using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Hurtbox : MonoBehaviour {


    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnTriggerEnter()
    {

    }
}
