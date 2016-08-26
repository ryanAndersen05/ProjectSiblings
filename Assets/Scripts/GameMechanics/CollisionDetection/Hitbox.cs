using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Hitbox : MonoBehaviour {
    Transform parentObject;
    
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().isKinematic = true;
        parentObject = transform.parent;
        while (parentObject.parent != null)
        {
            parentObject = parentObject.parent;
        }
	}

    void OnTriggerEnter2D (Collider2D collider)
    {
        Hitbox hitbox = collider.GetComponent<Hitbox>();
        Hurtbox hurtbox = collider.GetComponent<Hurtbox>();
        if (hurtbox != null)
        {

        }
        else if (hitbox != null)
        {

        }
    }

    protected virtual void onHitboxEntered(Hitbox hBox)
    {

    }

    protected virtual void onHurtboxEntered(Hurtbox hBox)
    {

    }

    public Transform getParentObject()
    {
        return parentObject;
    }
}
