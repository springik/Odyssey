using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    [SerializeField]
    public ESlot equipmentSlot;
    [SerializeField]
    public int defenseModifier;
    [SerializeField]
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.Instance.Equip(this);
        Remove();
    }
}
public enum ESlot
{
    Weapon,
    Armor
}
