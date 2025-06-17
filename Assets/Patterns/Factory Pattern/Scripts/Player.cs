using UnityEngine;

public class Player : MonoBehaviour
{
    #region EQUIPMENT FACTORY

    [SerializeField] private EquipmentFactory equipmentFactory;
    private IWeapon _weapon;
    private IShield _shield;

    #endregion
    
    #region UNITY METHODS
    void Start()
    {
        _weapon = equipmentFactory.CreateWeapon();
        _shield = equipmentFactory.CreateShield();
        Attack();
        Defend();
    }

    private void Attack() => _weapon?.Attack();
    private void Defend() => _shield?.Defend();

    #endregion


}
