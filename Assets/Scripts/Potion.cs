using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Items/Potion")]
public class Potion : Item
{
    [SerializeField]
    int percentageHealingAmount;
    int healingAmount;

    private void Awake()
    {
        healingAmount = StatManager.Instance.stats[StatManager.Instance.stats.IndexOf(StatManager.getStatOfType("HP"))].currVal * percentageHealingAmount / 100;
    }

    public override void Use()
    {
        //Debug.Log(StatManager.Instance);
        StatManager.Instance.healDamage(healingAmount);
        Debug.Log("healed");
        Remove();
    }
}
