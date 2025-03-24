using UnityEngine;

public abstract class AgentState : BaseState<AgentStateMachine.EAgentState>
{
    #region AGENT CONTEXT
    protected AgentContext Context;
    #endregion

    #region AGENT STATE CONSTRUCTOR
    public AgentState(AgentContext context,AgentStateMachine.EAgentState stateKey) : base(stateKey)
    {
        Context = context;
    }
    #endregion
}
