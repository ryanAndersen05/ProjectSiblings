using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    MovementMechanics mMechanics;
    JumpMechanics jMechanics;
    Dialogue dialogue;

    void Start()
    {
        mMechanics = GetComponent<MovementMechanics>();
        dialogue = GetComponent<Dialogue>();
        jMechanics = GetComponent<JumpMechanics>();
    }

	void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        bool action = Input.GetButtonDown("Action");
        bool jump = Input.GetButtonDown("Jump");
        if (mMechanics != null)
        {
            mMechanics.setHorizontalInput(hInput);
        }
        if (dialogue != null)
        {
            dialogue.activatedDialogue(action);
        }
        if (jMechanics != null)
        {
            jMechanics.activateJump(jump);
        }
    }
}
