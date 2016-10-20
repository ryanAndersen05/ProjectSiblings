using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIStateMachine : MonoBehaviour {
    public State[] allValidStates;
    Dictionary<string, State> dictionaryStates;
    State currentState;

    void Start()
    {
        dictionaryStates = new Dictionary<string, State>();
        foreach (State s in allValidStates)
        {
            State sState = ((GameObject)Instantiate(s.gameObject, Vector3.zero, new Quaternion())).GetComponent<State>();
            sState.transform.parent = this.transform;
            sState.gameObject.SetActive(false);
            dictionaryStates.Add(sState.stateName, sState);
        }
        changeCurrentState(allValidStates[0].stateName);
    }

    public void changeCurrentState(string newStateName)
    {
        if (currentState != null ) currentState.exitState();
        if (dictionaryStates.ContainsKey(newStateName))
        {
            currentState = dictionaryStates[newStateName];
        }
        currentState.enterState(this);
    }

    public Transform getParent()
    {
        return this.transform.parent;
    }
}
