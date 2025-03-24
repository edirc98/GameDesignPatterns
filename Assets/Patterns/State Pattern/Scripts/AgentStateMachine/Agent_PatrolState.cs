using UnityEngine;

public class Agent_PatrolState : AgentState
{
    #region STATE CONSTRUCTOR
    public Agent_PatrolState(AgentContext context, AgentStateMachine.EAgentState EState) : base(context, EState)
    {
        AgentContext Context = context;
    }
    #endregion

    #region STATE METHODS
    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }
    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override AgentStateMachine.EAgentState GetNextState()
    {
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider other)
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
