using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Generic Shield Factory", menuName = "Shield Factory/Shield")]
public class GenericShieldFactory : ShieldFactory
{
    public override IShield CreateShield()
    {
        return new Shield();
    }
}
