using UnityEngine;

public class Agent_SleepState : AgentState
{
    #region STATE VARIABLES
    private float _elapsedTime;
    private float _timeInSleep = 5.0f;
    private float minDistanceToBed = 2.0f;

    private bool _startedSleep = false;
    private bool _finishedSleep = false;
    #endregion
    #region STATE CONSTRUCTOR
    public Agent_SleepState(AgentContext context, AgentStateMachine.EAgentState EState) : base(context, EState)
    {
        AgentContext Context = context;
    }
    #endregion

    #region STATE METHODS
    public override void EnterState()
    {
        Context.Agent_StateText = StateKey.ToString();
        _elapsedTime = 0; 
    }
    public override void UpdateState()
    {
        //Agent go to the bed
        Vector3 lookDir = (Context.Agent_Bed.position - Context.Agent_Transform.position).normalized;
        Context.Agent_Transform.forward = Vector3.Lerp(Context.Agent_Transform.forward, new Vector3(lookDir.x, 0, lookDir.z), Time.deltaTime * 2);

        Context.Agent_Rigidbody.linearVelocity = Context.Agent_Transform.forward * Context.Agent_Speed;

        //Once close to the bed it starts sleeping
        float currentDistance = Vector3.Distance(Context.Agent_Transform.position, Context.Agent_Bed.position);
        if (currentDistance < minDistanceToBed)
        {
            _startedSleep = true;
            Context.Agent_Rigidbody.linearVelocity = Vector3.zero;
        }

        if (_startedSleep)
        {
            _elapsedTime += Time.deltaTime;
        }
        if(_elapsedTime > _timeInSleep)
        {
            _finishedSleep = true;
        }
    }

    public override void ExitState()
    {
        Context.Agent_Rigidbody.linearVelocity = Vector3.zero;
        _startedSleep = false;
        _finishedSleep = false;
    }

    public override AgentStateMachine.EAgentState GetNextState()
    {
        if(_startedSleep && _finishedSleep)
        {
            //Once finished sleeped goes back to PATROL state
            return AgentStateMachine.EAgentState.PATROL;
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
}
