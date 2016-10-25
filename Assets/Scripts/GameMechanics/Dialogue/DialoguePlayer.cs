using UnityEngine;
using System.Collections;

public class DialoguePlayer : MonoBehaviour {
    public NPCDialogue npcDialogue;
    DialogueUI dialogueUI;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        dialogueUI = GameObject.FindObjectOfType<DialogueUI>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        NPCDialogue npc = collider.GetComponent<NPCDialogue>();
        if (npc != null)
        {
            if (this.npcDialogue != null)
                this.npcDialogue.resetCount();
            this.npcDialogue = npc; 
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            if (this.npcDialogue.getIsActiveDialogue())
            {

            }
        }
    }
}
