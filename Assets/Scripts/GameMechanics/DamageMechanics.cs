using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class DamageMechanics : MonoBehaviour, IHitboxReaction
{
    public float baseDamage = 5;
    List<Hurtbox> hurtBoxList = new List<Hurtbox>();

    void resetHurtboxList()
    {
        hurtBoxList.Clear();
    }

    bool containsHurtbox(Hurtbox hBox)
    {
        foreach (Hurtbox h in hurtBoxList)
        {
            if (h.parentObject == hBox.parentObject) return true;
        }
        return false;
    }

    public virtual void onHitboxEntered(Hitbox hBox)
    {
        
    }

    public virtual void onHitboxExit(Hitbox hBox)
    {
        
    }

    public virtual void onHurtboxEntered(Hurtbox hBox)
    {
        
    }

    public virtual void onHurtboxExit(Hurtbox hBox)
    {
        
    }

    public virtual void onDefaultEnter(Collider2D collider)
    {

    }

    public virtual void onDefaultExit(Collider2D collider)
    {

    }
}
