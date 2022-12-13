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
        Debug.Log("----------HP POT HEAL:");
        Debug.Log(StatManager.Instance.stats[StatManager.Instance.stats.IndexOf(StatManager.getStatOfType("HP"))].currVal);
        Debug.Log(healingAmount);
    }

    public override void Use()
    {
        throw new NotImplementedException();
    }
}
