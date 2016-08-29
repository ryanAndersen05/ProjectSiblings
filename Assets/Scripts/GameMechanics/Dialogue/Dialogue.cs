using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {
    NPCDialogue npcDialogue;
    FlipSprite fSprite;
    Rigidbody2D rigid;
    Animator anim;
    DialogueUI dialogueUI;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        fSprite = GetComponent<FlipSprite>();
        dialogueUI = GameObject.FindObjectOfType<DialogueUI>();
    }


    public bool activatedDialogue(bool buttonDown)
    {
        if (buttonDown && npcDialogue && !dialogueUI.isActive)
        {
            dialogueUI.activateConversation(npcDialogue.dialogueFileName);
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

    void Update()
    {

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
