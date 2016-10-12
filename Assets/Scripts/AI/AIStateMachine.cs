using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIStateMachine : MonoBehaviour {
    public State[] allValidStates;
    State currentState;

    void Start()
    {
        List<State> validStateList = new List<State>();
        foreach (State s in allValidStates)
        {
            State sState = ((GameObject)Instantiate(s.gameObject, Vector3.zero, new Quaternion())).GetComponent<State>();
            validStateList.Add(sState);
        }
        allValidStates = validStateList.ToArray();
    }


}
