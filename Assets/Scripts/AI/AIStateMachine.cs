using UnityEngine;
using System.Collections;

public class AIStateMachine : MonoBehaviour {
    public State[] allValidStates;
    State currentState;

    void Start()
    {
        foreach (State s in allValidStates)
        {
            State sState = ((GameObject)Instantiate(s.gameObject, Vector3.zero, new Quaternion())).GetComponent<State>();
        }
    }


}
