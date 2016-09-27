using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsUINode : MonoBehaviour {
    public OptionsUINode northNode;
    public OptionsUINode southNode;
    public OptionsUINode eastNode;
    public OptionsUINode westNode;

    RectTransform pointerPosition;
    Button optionButton;
    public bool isCurrentNode = false;

    void Start()
    {
        optionButton = GetComponent<Button>();   
    }

    void Update()
    {
        if (!isCurrentNode) return;
        if (Input.GetButtonDown("Action"))
        {
            optionButton.onClick.Invoke();
        }
    }
}
