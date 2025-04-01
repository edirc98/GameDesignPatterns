using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region VARIABLES
    [Header("Pool Object")]
    public GameObject poolObject;
    public int poolSize = 5;
    public bool poolExpandable = false;
    #endregion

    #region SINGLETON INTANCE
    private static ObjectPool _instance; //Singleton self reference
    public static ObjectPool Instance { get { return _instance; } private set { _instance = value; } }
    #endregion
    #region SINGLETON CHECK
    private void SingletonCheckSingleInstance()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion
    #region POOL LIST
    [SerializeField] private List<GameObject> pooledObjects;
    #endregion

    private void Awake()
    {
        SingletonCheckSingleInstance();
    }

    void Start()
    {
        StartPool();
    }

    #region METHODS
    private GameObject GeneratePoolObject()
    {
        GameObject poolObjInstance = Instantiate(poolObject, transform);
        poolObjInstance.SetActive(false);
        pooledObjects.Add(poolObjInstance);

        return poolObjInstance;
    }
    private void StartPool()
    {
        pooledObjects = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            GeneratePoolObject();
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeSelf)
            {
                return pooledObjects[i];
            }
        }
        //If list is expandable, if there is no pooled object available create one and add it to the list
        if (poolExpandable)
        {
            return GeneratePoolObject();
        }
        return null;
    }
    #endregion
}
