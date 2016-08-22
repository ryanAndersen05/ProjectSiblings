using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }


    public void activatedDialogue(bool buttonDown)
    {
        if (buttonDown)
        {
            anim.SetTrigger("Dialogue");
        }
    }
}
