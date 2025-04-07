using UnityEngine;

public class UseageExample : MonoBehaviour
{
    #region UNITY METHODS
    void Start()
    {
        GetSingletonName();

        //Using the generics
        ManagerGeneric.Instance.AddScore(5);
        Debug.Log("Using the generic: " + ManagerGeneric.Instance.Score);
    }

    void Update()
    {
        
    }
    #endregion

    #region CUSTOM METHODS
    private void GetSingletonName()
    {
        ManagerExample.Instance.GetInstanceName();
    }
    #endregion
}
