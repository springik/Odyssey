using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

public class StatManager : MonoBehaviour
{
    #region singleton
    public static StatManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Více instancí Equip manager a to je velký špatný");
            return;
        }
        Instance = this;
    }
    #endregion

    [SerializeField]
    public List<Stat> stats;
    public delegate string statIncreased(string type);
    public int statPoints { get; private set; } = 1;
    float experience = 0;
    int level = 1;
    [SerializeField]
    float expBase = 300;
    float expReq;
    public UnityAction<float> statsChanged;
    //public UnityEvent<string> addPoint;

    private void Start()
    {
        foreach (Stat stat in stats)
        {
            stat.CalculateStat();
            stat.calculateRealVal();
        }
        //statsChanged.Invoke(getStatOfType("HP").realVal);
        expReq = level * expBase;
        //addPoint.AddListener(AddPointToStat);
    }
    void levelUp()
    {
        if (experience >= expReq)
        {
            level++;
            experience -= expReq;
            updateExpReq();
        }
    }

    private void updateExpReq()
    {
        expReq = level * expBase;
    }

    public void AddPointToStat(string type)
    {
        if (statPoints <= 0)
        {
            return;
        }
        foreach (Stat stat in stats)
        {
            if (stat.type == type)
            {
                stat.AddPoint();
                statPoints--;
            }
        }
        //statsChanged.Invoke(getStatOfType("HP").realVal);
    }
    public void takeDamage(int amount)
    {
        Debug.Log("Dal dmg");
        amount -= getStatOfType("ARM").currVal;
        getStatOfType("HP").decreaseRealVal(amount);
        //statsChanged.Invoke(getStatOfType("HP").realVal);
    }
    public void healDamage(int amount)
    {
        //Debug.Log(getStatOfType("HP").type);
        getStatOfType("HP").increaseRealVal(amount);
        //Debug.Log(getStatOfType("HP").realVal);
        //statsChanged.Invoke(getStatOfType("HP").realVal);
    }

    public static Stat getStatOfType(string type)
    {
        foreach (Stat stat in StatManager.Instance.stats)
        {
            if (stat.type == type)
            {
                return stat;
            }
        }
        return null;
    }
}
