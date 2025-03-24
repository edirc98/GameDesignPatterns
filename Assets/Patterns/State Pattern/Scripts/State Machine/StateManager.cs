using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    #region STATES
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> CurrentState;
    #endregion

    #region MANAGER PROPERTIES
    private bool IsTransitioningState = false;
    #endregion

    #region UNITY METHODS
    private void Start()
    {
        CurrentState.EnterState();
    }
    private void Update()
    {
        EState nextStateKey = CurrentState.GetNextState();

        if (!IsTransitioningState && nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }
        else if(!IsTransitioningState)
        {
            TransitionToNextState(nextStateKey);
        }
    }
    #endregion

    #region TRANSITION METHOD
    private void TransitionToNextState(EState stateKey)
    {
        Debug.Log("Chaning to state: " + stateKey.ToString());
        IsTransitioningState = true;
        CurrentState.ExitState();

        CurrentState = States[stateKey];

        CurrentState.EnterState();
        IsTransitioningState = false;
    }
    #endregion

    #region TRIGEGR METHODS
    private void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }
    private void OnTriggerStay(Collider other) 
    {
        CurrentState.OnTriggerStay(other);
    }
    private void OnTriggerExit(Collider other) 
    {
        CurrentState.OnTriggerExit(other);
    }
    #endregion

    

}
