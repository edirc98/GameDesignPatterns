using UnityEngine;

public class UseageExample : MonoBehaviour
{
    #region UNITY METHODS
    void Start()
    {
        GetSingletonName();
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
