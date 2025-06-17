using UnityEngine;

[CreateAssetMenu(fileName = "Equipment Factory", menuName = "Equipment Factory/Equipment")]

public class EquipmentFactory : ScriptableObject
{
    public WeaponFactory weaponFactory;
    public ShieldFactory shieldFactory;


    public IWeapon CreateWeapon()
    {
        return weaponFactory != null ? weaponFactory.CreateWeapon() : IWeapon.CreateDefault();
    }

    public IShield CreateShield()
    {
        return shieldFactory != null ? shieldFactory.CreateShield() : IShield.CreateDefault();
    }
    
    
}
