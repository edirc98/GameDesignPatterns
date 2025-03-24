using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class AgentContext
{

    #region AGENT VARIABLES
    private float _speed;
    private int _currentWaypointIndex; 
    private Rigidbody _rigidbody;
    private Collider _rootCollider;
    private TextMeshPro _stateText;
    private List<GameObject> _waypoints;

    #endregion

    #region AGENT PROPERTIES
    public float Agent_Speed { get { return _speed; } }
    public int Agent_WaypointIndex { get { return _currentWaypointIndex; } set { _currentWaypointIndex = value; } }
    public Rigidbody Agent_Rigidbody { get { return _rigidbody; } }
    public Collider Agent_Collider { get { return _rootCollider; } }
    public string Agent_StateText { get { return _stateText.text; } set { _stateText.text = value; }}
    public List<GameObject> Agent_Waypoint { get { return _waypoints; } }

    #endregion

    #region CONTEXT CONSTRUCTOR
    public AgentContext(float agentSpeed, int startWaypointIndex, Rigidbody rb, Collider col, TextMeshPro stateText, List<GameObject> Waypoints)
    {
        _speed = agentSpeed;
        _currentWaypointIndex = startWaypointIndex; 
        _rigidbody = rb;
        _rootCollider = col;
        _stateText = stateText;
        _waypoints = Waypoints;
    }
    #endregion
}
