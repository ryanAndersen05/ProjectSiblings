using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIStateMachine : MonoBehaviour {
    public State[] allValidStates;
    Dictionary<string, State> dictionaryStates;
    State currentState;

    void Start()
    {
        List<State> validStateList = new List<State>();
        foreach (State s in allValidStates)
        {
            State sState = ((GameObject)Instantiate(s.gameObject, Vector3.zero, new Quaternion())).GetComponent<State>();
            sState.transform.parent = this.transform;
            sState.gameObject.SetActive(false);
            validStateList.Add(sState);
        }
        
    }

    void Update()
    {
        currentState.updateState();
    }


    public void changeCurrentState(string newStateName)
    {
        currentState.exitState();
        if (dictionaryStates.ContainsKey(newStateName))
        {
            currentState = dictionaryStates[newStateName];
        }
        currentState.enterState(this);
    }
}
