using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : Stats
{
    public int level { get; private set; }
    public Stat exp;
    public int currExp { get; private set; }
    [SerializeField]
    int xpScale;
    public int requiredExp { get; private set; }
    public int availablePoints { get; private set; } = 1;
    public UnityAction onLevelUp;

    private void Start()
    {
        requiredExp = level * xpScale;
        EquipmentManager.Instance.onEquipChanged += OnEquipChanged;
        foreach (Stat stat in stats)
        {
            Debug.Log(stat + stat.type);
        }
        onStatChanged.Invoke();
    }

    private void OnEquipChanged(Equipment nItem, Equipment oItem)
    {
        if (nItem != null)
        {
            def.addMod(nItem.defenseModifier);
            dmg.addMod(nItem.damageModifier);
            onStatChanged.Invoke();
        }
        if (oItem != null)
        {
            def.removeMod(oItem.defenseModifier);
            dmg.removeMod(oItem.damageModifier);
            onStatChanged.Invoke();
        }
    }
    public void addToStat(string type)
    {
        if(availablePoints > 0)
        {
            findStat(type)?.addPoint();
            availablePoints--;
        }
    }

    public Stat findStat(string type)
    {
        foreach (Stat stat in stats)
        {
            if(stat.type == type)
                return stat;
        }
        return null;
    }
}
