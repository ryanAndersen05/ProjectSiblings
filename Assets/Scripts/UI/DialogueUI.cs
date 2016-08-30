using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueUI : MonoBehaviour {
    public Image portraitRight;
    public Image portraitLeft;
    public Image nameBoxRight;
    public Image nameBoxLeft;
    public Image dialogueBox;
    public Text dialogueText;
    public Text nameLeft;
    public Text nameRight;

    public bool isActive;
    public bool isRight;
    public float coolDownTime = .02f;
    public float coolDownTimeEnd = 1;
    DialogueNode[] dNodes;
    int currentDialogueSegment = 0;
    public float coolDownTimer = 0;

    public bool activateConversation(string fileName)
    {
        if (coolDownTimer > 0) return false;
        dNodes = DialogueFileParser.parseDialogueFile(fileName);
        dialogueBox.gameObject.SetActive(true);
        dialogueText.text = dNodes[0].dialogueSegment;
        nameBoxLeft.gameObject.SetActive(true);
        nameLeft.text = dNodes[0].characterName;
        isActive = true;
        currentDialogueSegment = 0;
        coolDownTimer = coolDownTime;
        return true;
    }

    void Update()
    {
        if (isActive && Input.GetButtonDown("Action") && coolDownTimer <= 0)
        {
            nextDialogue();
            
        }
        coolDownTimer = Mathf.MoveTowards(coolDownTimer, 0, Time.deltaTime);
    }

    void nextDialogue()
    {
        currentDialogueSegment++;
        if (currentDialogueSegment >= dNodes.Length)
        {
            isActive = false;
            dialogueBox.gameObject.SetActive(false);
            nameBoxLeft.gameObject.SetActive(false);
            nameBoxRight.gameObject.SetActive(false);
            coolDownTimer = coolDownTimeEnd;
            return;
        }
        if (dNodes[currentDialogueSegment].characterName != dNodes[currentDialogueSegment - 1].characterName)
        {
            isRight = !isRight;
        }
        
        if (isRight)
        {
            
            nameBoxLeft.gameObject.SetActive(false);
            nameBoxRight.gameObject.SetActive(true);
            nameRight.text = dNodes[currentDialogueSegment].characterName;
        }
        else
        {
            
            nameBoxRight.gameObject.SetActive(false);
            nameBoxLeft.gameObject.SetActive(true);
            nameLeft.text = dNodes[currentDialogueSegment].characterName;
        }
        //print(dNodes[currentDialogueSegment].characterName + ":" + dNodes[currentDialogueSegment].dialogueSegment);
        dialogueText.text = dNodes[currentDialogueSegment].dialogueSegment;
        coolDownTimer = coolDownTime;
    }

}
