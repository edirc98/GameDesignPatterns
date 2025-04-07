using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }

    public virtual void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this as T; 
    }
}
