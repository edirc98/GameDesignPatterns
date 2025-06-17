using UnityEngine;

public abstract class WeaponFactory : ScriptableObject
{
    public abstract IWeapon CreateWeapon();
}