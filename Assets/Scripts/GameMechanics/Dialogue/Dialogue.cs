using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {
    public float maxBuffer = .3f;
    float dialogueBuffer = 0;
    NPCDialogue npcDialogue;
    FlipSprite fSprite;
    Rigidbody2D rigid;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody2D>();
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
        if (buttonDown) dialogueBuffer = maxBuffer;
        return false;
    }

    void Update()
    {
        if (dialogueBuffer > 0)
        {
            activatedDialogue(true);
        }
        else
        {
            anim.ResetTrigger("Dialogue");
        }
        dialogueBuffer = Mathf.MoveTowards(dialogueBuffer, 0, Time.deltaTime);
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
