using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    MovementMechanics mMechanics;
    Dialogue dialogue;

    void Start()
    {
        mMechanics = GetComponent<MovementMechanics>();
        dialogue = GetComponent<Dialogue>();
    }

	void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        bool action = Input.GetButtonDown("Action");
        if (mMechanics != null)
        {
            mMechanics.setHorizontalInput(hInput);
        }
        if (dialogue != null)
        {
            dialogue.activatedDialogue(action);
        }
    }
}
