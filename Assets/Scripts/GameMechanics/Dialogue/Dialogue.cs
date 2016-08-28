using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {
    NPCDialogue npcDialogue;
    FlipSprite fSprite;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        fSprite = GetComponent<FlipSprite>();
    }


    public bool activatedDialogue(bool buttonDown)
    {
        if (buttonDown && npcDialogue)
        {
            
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
