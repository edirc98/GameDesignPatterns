using UnityEngine;

public class UnityObserver : MonoBehaviour
{

    #region SUBJECT REF
    [SerializeField] private UnitySubject _subject;
    #endregion

    #region UNITY METHODS
    private void OnEnable()
    {
        _subject.OnKeyPressedEvent.AddListener(InvokeResponse);
    }
    private void OnDisable()
    {
        _subject.OnKeyPressedEvent.RemoveListener(InvokeResponse);
    }
    #endregion

    #region OBSERVER RESPONSE
    private void InvokeResponse()
    {
        Debug.Log("Response to Untiy Event from " + name);
    }
    #endregion
}
