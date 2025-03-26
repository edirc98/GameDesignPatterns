using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class AgentContext
{

    #region AGENT VARIABLES
    private float _speed;
    private int _currentWaypointIndex;
    private Transform _transform;
    private Rigidbody _rigidbody;
    private Collider _rootCollider;
    private TextMeshPro _stateText;
    private List<GameObject> _waypoints;
    private Transform _bed;

    #endregion

    #region AGENT PROPERTIES
    public float Agent_Speed { get { return _speed; } }
    public int Agent_WaypointIndex { get { return _currentWaypointIndex; } set { _currentWaypointIndex = value; } }
    public Transform Agent_Transform { get { return _transform; } }
    public Rigidbody Agent_Rigidbody { get { return _rigidbody; } }
    public Collider Agent_Collider { get { return _rootCollider; } }
    public string Agent_StateText { get { return _stateText.text; } set { _stateText.text = value; } }
    public List<GameObject> Agent_Waypoints { get { return _waypoints; } }
    public Transform Agent_Bed { get { return _bed; } }

    #endregion

    #region CONTEXT CONSTRUCTOR
    public AgentContext(float agentSpeed, int startWaypointIndex,Transform trf, Rigidbody rb, Collider col, TextMeshPro stateText, List<GameObject> Waypoints, Transform Bed)
    {
        _speed = agentSpeed;
        _currentWaypointIndex = startWaypointIndex;
        _transform = trf; 
        _rigidbody = rb;
        _rootCollider = col;
        _stateText = stateText;
        _waypoints = Waypoints;
        _bed = Bed;
    }
    #endregion
}
