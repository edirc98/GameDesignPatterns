using UnityEngine;

public class TestObserver : MonoBehaviour, IObserver
{
    #region SUBJECT REF

    [SerializeField] private TestSubject _subject;
    #endregion

    #region UNITY METHODS
    private void OnEnable()
    {
        AddSelfToSubjectList();
    }
    private void OnDisable()
    {
        RemoveSelfFromSubjectList();
    }
    #endregion

    #region OBSERVER REGISTRATION
    private void AddSelfToSubjectList()
    {
        _subject.AddObserver(this);
    }
    private void RemoveSelfFromSubjectList()
    {
        _subject.RemoveObserver(this);
    }
    #endregion

    #region OBSERVER NOTIFY RESPONSE
    public void OnNotify()
    {
        Debug.Log("Observer " + name + " recibed notify");
    }
    #endregion
}
