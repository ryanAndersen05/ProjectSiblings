using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public bool disableControls;
    MovementMechanics mMechanics;
    JumpMechanics jMechanics;
    SummonItemMechanics sItemMechanics;
    AttackMechanics aMechanics;
    ArcherMechanics archMechanics;
    BufferedInputs bInputs;

    void Start()
    {
        sItemMechanics = GetComponent<SummonItemMechanics>();
        mMechanics = GetComponent<MovementMechanics>();
        jMechanics = GetComponent<JumpMechanics>();
        aMechanics = GetComponent<AttackMechanics>();
        archMechanics = GetComponent<ArcherMechanics>();
        bInputs = new BufferedInputs();
        bInputs.addInputNode("Jump");
        bInputs.addInputNode("Action");
        bInputs.addInputNode("Attack", .2f);
        bInputs.addInputNode("Projectile");
    }

    void Update()
    {
        if (disableControls)
        {
            return;
        }
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        bool useItem = Input.GetButtonDown("UseItem");
        bInputs.resetBuffer("Attack");
        bInputs.resetBuffer("Jump");
        bInputs.resetBuffer("Action");
        bInputs.resetBuffer("Projectile");
        if (mMechanics != null)
        {
            mMechanics.setHorizontalInput(hInput);
        }
        if (sItemMechanics != null)
        {
            sItemMechanics.summonItem(useItem);
        }
        if (jMechanics != null)
        {
            bInputs.cancelBuffer("Jump", jMechanics.activateJump(bInputs.isActive("Jump")));
        }
        if (aMechanics != null)
        {

            bInputs.cancelBuffer("Attack", aMechanics.attack(bInputs.isActive("Attack")));
        }

        if (archMechanics != null)
        {
            archMechanics.chargeBow(Input.GetButton("Projectile"));
        }
        
        bInputs.updateInputs();
    }


}
