using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {
    public string stateName;
    protected AIStateMachine stateMachine;
    bool isActiveState;
    

    public virtual void enterState(AIStateMachine stateMachine)
    {
        this.isActiveState = true;
        this.stateMachine = stateMachine;
    }

    public virtual void exitState()
    {
        this.isActiveState = false;
    }

    public virtual void updateState()
    {

    }
}
