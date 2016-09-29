using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public bool disableControls;
    MovementMechanics mMechanics;
    JumpMechanics jMechanics;
    Dialogue dialogue;
    SummonItemMechanics sItemMechanics;
    BufferedInputs bInputs;

    void Start()
    {
        sItemMechanics = GetComponent<SummonItemMechanics>();
        mMechanics = GetComponent<MovementMechanics>();
        dialogue = GetComponent<Dialogue>();
        jMechanics = GetComponent<JumpMechanics>();
        bInputs = new BufferedInputs();
        bInputs.addInputNode("Jump");
        bInputs.addInputNode("Action");
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
        bInputs.resetBuffer("Jump");
        bInputs.resetBuffer("Action");

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
        if (dialogue != null)
        {
            bInputs.cancelBuffer("Action", dialogue.activatedDialogue(bInputs.isActive("Action")));
        }
        bInputs.updateInputs();
    }


}
