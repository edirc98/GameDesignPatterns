using UnityEngine;

[CreateAssetMenu(fileName = "Sword Factory", menuName = "Weapon Factory/Sword")]
public class SwordFactory : WeaponFactory
{
    public override IWeapon CreateWeapon()
    {
        return new Sword();
    }
}