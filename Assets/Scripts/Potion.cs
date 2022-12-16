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
        //get healing amount
    }

    public override void Use()
    {
        throw new NotImplementedException();
    }
}
