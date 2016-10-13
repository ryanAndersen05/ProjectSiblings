using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Hitbox : MonoBehaviour {
    public bool isContinuous;
    Transform parentObject;
    IHitboxReaction[] hitBoxReactions;
    
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().isKinematic = true;
        parentObject = transform.parent;
        while (parentObject.parent != null)
        {
            parentObject = parentObject.parent;
        }
        hitBoxReactions = parentObject.GetComponents<IHitboxReaction>();
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        Hitbox hitbox = collider.GetComponent<Hitbox>();
        Hurtbox hurtbox = collider.GetComponent<Hurtbox>();
        if (hurtbox != null)
        {
            print("Hurtbox");
            onHurtboxEntered(hurtbox);
        }
        else if (hitbox != null)
        {
            print("Hitbox");
            onHitboxEntered(hitbox);
        }
        else
        {
            print(collider.name);
            onDefaultColliderEntered(collider);
        }
        this.enabled = false;
    }

    void onHitboxEntered(Hitbox hBox)
    {
        foreach(IHitboxReaction hr in hitBoxReactions)
        {
            hr.onHitboxEntered(hBox);
        }
    }

    void onHurtboxEntered(Hurtbox hBox)
    {
        foreach (IHitboxReaction hr in hitBoxReactions)
        {
            hr.onHurtboxEntered(hBox);
        }
    }

    void onDefaultColliderEntered(Collider2D collider)
    {
        foreach (IHitboxReaction hr in hitBoxReactions)
        {
            hr.onDefaultEnter(collider);
        }
    }

    public Transform getParentObject()
    {
        return parentObject;
    }
}
