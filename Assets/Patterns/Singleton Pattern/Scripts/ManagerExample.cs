using UnityEngine;

public class ManagerExample : MonoBehaviour
{
    #region SINGLETON INTANCE
    private static ManagerExample _instance; //Singleton self reference
    public static ManagerExample Instance { get { return _instance; } private set { _instance = value; } } //Public acces for the manager instance 
    #endregion
    #region SINGLETON CHECK
    private void SingletonCheckSingleInstance()
    {
        if (_instance != null && _instance != this) //Check if there is a duplicated instance, so we can delete this one
        {
            Debug.Log("This is: " + name + " but there is another instance of me, deleting myself");
            Destroy(this.gameObject);
        }
        else 
        {
            Debug.Log("This is: " + name + " first instance");
            Instance = this; 
        } 
    }
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        SingletonCheckSingleInstance();
    }
    #endregion

    #region CUSTOM METHODS
    public void GetInstanceName()
    {
        Debug.Log("This instance is: " + name);
    }
    #endregion

}
