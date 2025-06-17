using UnityEngine;

public abstract class ShieldFactory : ScriptableObject
{
    public abstract IShield CreateShield();
}
