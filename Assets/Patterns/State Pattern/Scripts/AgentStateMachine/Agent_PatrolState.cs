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
        Debug.Log("Enter PATROL State");
        Context.Agent_StateText = StateKey.ToString();
        Context.Agent_Rigidbody.linearVelocity = Context.Agent_Transform.forward * Context.Agent_Speed;
    }
    public override void UpdateState()
    {
        Vector3 lookDir = (Context.Agent_Waypoint[Context.Agent_WaypointIndex].transform.position - Context.Agent_Transform.position).normalized;
        Context.Agent_Transform.forward = Vector3.Lerp(Context.Agent_Transform.forward, new Vector3(lookDir.x, 0, lookDir.z),Time.deltaTime);

        Context.Agent_Rigidbody.linearVelocity = Context.Agent_Transform.forward * Context.Agent_Speed;
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
