using System;
using UnityEngine;

public abstract class BaseState<EState> where EState : Enum
{
    #region STATE CONSTRUCTOR
    public BaseState(EState key)
    {
        StateKey = key;
    }
    #endregion

    #region STATE PROPERTIES
    public EState StateKey { get; private set; }
    #endregion

    #region STATE METHODS
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();
    #endregion

    #region STATE TRIGGERS
    public abstract void OnTriggerEnter(Collider other);
    public abstract void OnTriggerStay(Collider other);
    public abstract void OnTriggerExit(Collider other);
    #endregion
}
