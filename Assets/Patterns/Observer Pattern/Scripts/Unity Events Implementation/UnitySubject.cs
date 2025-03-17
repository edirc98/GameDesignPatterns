using UnityEngine;
using UnityEngine.Events;


public class UnitySubject : MonoBehaviour
{
    #region UNITY EVENT
    public UnityEvent OnKeyPressedEvent;
    #endregion

    #region UNITY METHODS
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnKeyPressedInvoke();
        }
    }

    private void OnKeyPressedInvoke()
    {
        Debug.Log("Invoked Unity Event from " + name);
        OnKeyPressedEvent.Invoke();
    }

    #endregion
}
