using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class AgentStateMachine : StateManager<AgentStateMachine.EAgentState>
{
    #region AGENT STATES
    public enum EAgentState
    {
        IDLE,
        PATROL,
        SLEEP,
    }
    #endregion

    #region AGENT VARIABLES
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _rootCollider;
    [SerializeField] private TextMeshPro _stateText;
    #endregion
    #region AGENT CONTEXT
    [SerializeField] private AgentContext _context; 
    #endregion

    #region UNTIY METHODS
    private void Awake()
    {
        GetAgentProperties();
        ValidateProperties();
        _context = new AgentContext(_rigidbody, _rootCollider, _stateText);
        InitAgentStates();
    }
    #endregion

    #region METHODS
    private void GetAgentProperties()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rootCollider = GetComponent<Collider>();
        _stateText = GetComponentInChildren<TextMeshPro>();
    }
    private void ValidateProperties()
    {
        Assert.IsNotNull(_rigidbody, "Rigidbody is null, Check if was assigned!");
        Assert.IsNotNull(_rootCollider, "Collider is null, Check if was assigned!");
        Assert.IsNotNull(_stateText, "State Text i null, Check if was assigned!");
    }

    private void InitAgentStates()
    {
        //Adds the states to the StateManager "States" Dictionary and sets an initial state
        States.Add(EAgentState.IDLE, new Agent_IdleState(_context, EAgentState.IDLE));
        States.Add(EAgentState.PATROL, new Agent_IdleState(_context, EAgentState.PATROL));
        States.Add(EAgentState.SLEEP, new Agent_IdleState(_context, EAgentState.SLEEP));

        CurrentState = States[EAgentState.IDLE];
    }
    #endregion

}
