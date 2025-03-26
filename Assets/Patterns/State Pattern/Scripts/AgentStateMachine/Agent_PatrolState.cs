using UnityEngine;

public class Agent_PatrolState : AgentState
{
    #region STATE VARIABLES
    float minDistanceToWaypoint = 1.0f;
    #endregion

    #region STATE CONSTRUCTOR
    public Agent_PatrolState(AgentContext context, AgentStateMachine.EAgentState EState) : base(context, EState)
    {
        AgentContext Context = context;
    }
    #endregion

    #region STATE METHODS
    public override void EnterState()
    {
        Context.Agent_StateText = StateKey.ToString();
        //Context.Agent_Rigidbody.linearVelocity = Context.Agent_Transform.forward * Context.Agent_Speed;
        
    }
    public override void UpdateState()
    {
        Vector3 lookDir = (Context.Agent_Waypoints[Context.Agent_WaypointIndex].transform.position - Context.Agent_Transform.position).normalized;
        Context.Agent_Transform.forward = Vector3.Lerp(Context.Agent_Transform.forward, new Vector3(lookDir.x, 0, lookDir.z), Time.deltaTime * 2);

        Context.Agent_Rigidbody.linearVelocity = Context.Agent_Transform.forward * Context.Agent_Speed;
    }

    public override void ExitState()
    {
        Context.Agent_Rigidbody.linearVelocity = Vector3.zero;
        UpdateTargetWaypoint(); //Next patrol will go to the next point
    }

    public override AgentStateMachine.EAgentState GetNextState()
    {
        float currentDistance = Vector3.Distance(Context.Agent_Transform.position, Context.Agent_Waypoints[Context.Agent_WaypointIndex].transform.position);
        if (currentDistance < minDistanceToWaypoint)
        {
            return AgentStateMachine.EAgentState.IDLE;
        }
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

    #region METHODS
    private void UpdateTargetWaypoint()
    {
        Context.Agent_WaypointIndex = (Context.Agent_WaypointIndex + 1) % Context.Agent_Waypoints.Count;
    }
    #endregion
}
