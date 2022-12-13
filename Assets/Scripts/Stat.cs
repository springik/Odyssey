using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
[Serializable]
public class Stat
{
    [SerializeField]
    public string type;
    [SerializeField]
    int baseVal;
    public int currVal { get; set; }
    [SerializeField]
    int maxVal;
    int points = 1;
    public int realVal { get; private set; }

    public void decreaseRealVal(int amount)
    {
        realVal -= amount;
    }
    public void increaseRealVal(int amount)
    {
        realVal += amount;
    }
    public void calculateRealVal()
    {
        realVal = currVal;
    }
    public void CalculateStat()
    {
        this.currVal = this.baseVal += this.baseVal * this.points;
    }
    public void AddPoint(string type)
    {
        if (points >= maxVal)
        {
            return;
        }
        this.points++;
        this.CalculateStat();
    }
}
