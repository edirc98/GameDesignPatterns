using UnityEngine;
using UnityEngine.Assertions;
using TMPro;
using System.Collections.Generic;
using System.Linq;

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
    [Header("Agent Properties")]
    [SerializeField] private float speed;
    [SerializeField] private Transform _waypointsParent;
    [Header("Agent Components")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _rootCollider;
    [SerializeField] private TextMeshPro _stateText;
    [SerializeField] private GameObject _bed; 
    [SerializeField] private List<GameObject> _waypoints;
    private int _currentWaypointIndex = 0; 
    #endregion

    #region AGENT CONTEXT
    [SerializeField] private AgentContext _context; 
    #endregion

    #region UNTIY METHODS
    private void Awake()
    {
        GetAgentProperties();
        ValidateProperties();
        GetAgentWaypoints();
        _context = new AgentContext(speed,_currentWaypointIndex,transform,_rigidbody, _rootCollider, _stateText, _waypoints);
        InitAgentStates();
    }
    #endregion

    #region METHODS
    private void GetAgentProperties()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rootCollider = GetComponent<Collider>();
        _stateText = GetComponentInChildren<TextMeshPro>();
        _bed = GameObject.Find("Bed");
    }
    private void GetAgentWaypoints()
    {
        _waypointsParent = GameObject.Find("Waypoints").transform;

       foreach(Transform Child in _waypointsParent)
        {
            _waypoints.Add(Child.gameObject);
        }
    }
    private void ValidateProperties()
    {
        Assert.IsNotNull(_rigidbody, "Rigidbody is null, Check if was assigned!");
        Assert.IsNotNull(_rootCollider, "Collider is null, Check if was assigned!");
        Assert.IsNotNull(_stateText, "State Text i null, Check if was assigned!");
        Assert.IsNotNull(_waypoints, "No Waypoints found, value is null, Check if was assigned!");

    }

    private void InitAgentStates()
    {
        //Adds the states to the StateManager "States" Dictionary and sets an initial state
        States.Add(EAgentState.IDLE, new Agent_IdleState(_context, EAgentState.IDLE));
        States.Add(EAgentState.PATROL, new Agent_PatrolState(_context, EAgentState.PATROL));
        States.Add(EAgentState.SLEEP, new Agent_SleepState(_context, EAgentState.SLEEP));

        CurrentState = States[EAgentState.IDLE];
    }
    #endregion

}
