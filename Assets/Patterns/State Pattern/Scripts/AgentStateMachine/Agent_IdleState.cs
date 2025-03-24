using UnityEngine;

public class Agent_IdleState : AgentState
{
    #region STATE CONSTRUCTOR
    public Agent_IdleState(AgentContext context, AgentStateMachine.EAgentState EState) : base(context, EState)
    {
        AgentContext Context = context;
    }
    #endregion

    #region STATE METHODS
    public override void EnterState()
    {
        Debug.Log("Enter Agent Idle State");
        Context.Agent_StateText = StateKey.ToString();
    }
    public override void UpdateState()
    {
        Debug.Log("Update Agent Idle State");
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
