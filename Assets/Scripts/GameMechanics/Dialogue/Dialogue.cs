using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {
    NPCDialogue npcDialogue;
    FlipSprite fSprite;
    Animator anim;
    DialogueUI dialogueUI;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        fSprite = GetComponent<FlipSprite>();
        dialogueUI = GameObject.FindObjectOfType<DialogueUI>();
    }


    public bool activatedDialogue(bool buttonDown)
    {
        if (buttonDown && npcDialogue && !dialogueUI.isActive)
        {
            bool dialogueActivated = dialogueUI.activateConversation(npcDialogue, this);
            if (!dialogueActivated)
            {
                return false;
            }
            float direction = transform.position.x - npcDialogue.transform.position.x;
            if (direction > 0)
            {
                fSprite.isRight = false;
            }
            else
            {
                fSprite.isRight = true;
            }

            fSprite.updateDirection();
            anim.SetTrigger("Dialogue");
            return true;
        }
        return false;
    }

    public void endDialogue()
    {
        if (!dialogueUI.isActive)
        {
            anim.SetTrigger("Dialogue");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        NPCDialogue checkDialogue = collider.GetComponent<NPCDialogue>();
        if (checkDialogue)
        {
            npcDialogue = checkDialogue;

        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        NPCDialogue checkDialogue = collider.GetComponent<NPCDialogue>();
        if (checkDialogue)
        {
            npcDialogue = null;
        }
    }
}
