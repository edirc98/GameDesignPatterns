using UnityEngine;

public class Agent_IdleState : AgentState
{
    #region STATE VARIABLES
    private float _elapsedTime;
    private float _timeInIdle = 3.0f;
    #endregion
    #region STATE CONSTRUCTOR
    public Agent_IdleState(AgentContext context, AgentStateMachine.EAgentState EState) : base(context, EState)
    {
        AgentContext Context = context;
    }
    #endregion

    #region STATE METHODS
    public override void EnterState()
    {
        Context.Agent_StateText = StateKey.ToString();

        _elapsedTime = 0.0f;
        
    }
    public override void UpdateState()
    {
        //The agent stays 10 seconds on Idle state befor going to Patrol State
        _elapsedTime += Time.deltaTime;
    }

    public override void ExitState()
    {

    }

    public override AgentStateMachine.EAgentState GetNextState()
    {
        if(_elapsedTime >= _timeInIdle)
        {
            //After IDLE state, there is a chance to go to sleep state. 
            if (Random.Range(0, 100) < 25)
            {
                return AgentStateMachine.EAgentState.SLEEP;
            }
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
