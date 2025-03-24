using UnityEngine;
using TMPro;

public class AgentContext
{

    #region AGENT VARIABLES
    private Rigidbody _rigidbody;
    private Collider _rootCollider;
    private TextMeshPro _stateText;
    #endregion

    #region AGENT PROPERTIE
    public Rigidbody Agent_Rigidbody { get { return _rigidbody; } }
    public Collider Agent_Collider { get { return _rootCollider; } }
    public string Agent_StateText { get { return _stateText.text; } set { _stateText.text = value; }}

    #endregion

    #region CONTEXT CONSTRUCTOR
    public AgentContext(Rigidbody rb, Collider col, TextMeshPro stateText)
    {
        _rigidbody = rb;
        _rootCollider = col;
        _stateText = stateText;
    }
    #endregion
}
