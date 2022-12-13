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
    //public UnityEvent<string> addPoint;

    private void Start()
    {
        stats.ForEach(item => item.CalculateStat());
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
                stat.currVal++;
                statPoints--;
            }
        }
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
