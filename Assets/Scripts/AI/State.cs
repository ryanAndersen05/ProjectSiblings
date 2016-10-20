using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {
    public string stateName;
    protected AIStateMachine stateMachine;
    bool isActiveState;
    

    void Update()
    {
        updateState();
    }

    public virtual void enterState(AIStateMachine stateMachine)
    {
        this.isActiveState = true;
        this.stateMachine = stateMachine;
        this.gameObject.SetActive(true);
    }

    public virtual void exitState()
    {
        this.isActiveState = false;
        this.gameObject.SetActive(false);
    }

    public virtual void updateState()
    {

    }
}
