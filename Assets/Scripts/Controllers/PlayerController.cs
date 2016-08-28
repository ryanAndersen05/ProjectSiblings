using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    MovementMechanics mMechanics;
    JumpMechanics jMechanics;
    Dialogue dialogue;
    BufferedInputs bInputs;

    void Start()
    {
        mMechanics = GetComponent<MovementMechanics>();
        dialogue = GetComponent<Dialogue>();
        jMechanics = GetComponent<JumpMechanics>();
        bInputs = new BufferedInputs();
        bInputs.addInputNode("Jump");
        bInputs.addInputNode("Action");
    }

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        bInputs.resetBuffer("Jump");
        bInputs.resetBuffer("Action");

        if (mMechanics != null)
        {
            mMechanics.setHorizontalInput(hInput);
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
