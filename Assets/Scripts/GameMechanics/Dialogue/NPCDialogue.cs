﻿using UnityEngine;
using System.Collections.Generic;

public class NPCDialogue : MonoBehaviour {
    public string dialogueFileName;
    public Transform actionIcon;

    List<Collider2D> allColliders = new List<Collider2D>();

    void Start()
    {
        actionIcon.gameObject.SetActive(false);
        dialogueFileName = "/DialogueScripts/" + dialogueFileName;
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.GetComponent<DialoguePlayer>() != null)
        {
            allColliders.Add(collider);
            actionIcon.gameObject.SetActive(true);
        }
        
    }

    void OnTriggerExit2D (Collider2D collider)
    {
        if (allColliders.Contains(collider))
        {
            allColliders.Remove(collider);
        }
        if (allColliders.Count <= 0)
        {
            actionIcon.gameObject.SetActive(false);
        } 
    }

    public bool getIsActiveDialogue()
    {
        return allColliders.Count > 0;
    }

    public void resetCount()
    {

    }
}
