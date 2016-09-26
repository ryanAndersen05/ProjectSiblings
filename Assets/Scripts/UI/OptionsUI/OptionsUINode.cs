using UnityEngine;
using System.Collections;

public class OptionsUINode : MonoBehaviour {
    public OptionsUINode northNode;
    public OptionsUINode southNode;
    public OptionsUINode eastNode;
    public OptionsUINode westNode;

    RectTransform pointerPosition;
    public bool isCurrentNode = false;

    void Start()
    {
        
    }
}
