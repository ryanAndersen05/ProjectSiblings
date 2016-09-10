﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public bool disableControls;
    MovementMechanics mMechanics;
    JumpMechanics jMechanics;
    Dialogue dialogue;
    BufferedInputs bInputs;
    CustomGravity cGravity;

    void Start()
    {
        mMechanics = GetComponent<MovementMechanics>();
        dialogue = GetComponent<Dialogue>();
        jMechanics = GetComponent<JumpMechanics>();
        cGravity = GetComponent<CustomGravity>();
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
        bInputs.resetBuffer("Jump");
        bInputs.resetBuffer("Action");
        if (cGravity != null)
        {
            cGravity.setVerticalInput(vInput);
        }
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
