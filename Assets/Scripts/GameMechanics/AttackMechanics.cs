using UnityEngine;
using System.Collections;

public class AttackMechanics : MonoBehaviour {
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public bool attack(bool attackButton)
    {
        if (!attackButton)
        {
            anim.ResetTrigger("Attack");
            
        }

        if (attackButton && !anim.GetBool("Attack"))
        {

            anim.SetTrigger("Attack");
            
        }
        
        return false;
    }
}
