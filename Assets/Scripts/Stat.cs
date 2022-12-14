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
    int points = 0;
    public int realVal { get; private set; }

    public void decreaseRealVal(int amount)
    {
        if (realVal > 0)
            realVal -= amount;
    }
    public void increaseRealVal(int amount)
    {
        if(realVal < currVal)
            realVal += amount;
        Debug.Log(this.realVal);
    }
    public void calculateRealVal()
    {
        realVal = currVal;
    }
    public void CalculateStat()
    {
        this.currVal = this.baseVal += this.points * 10;
    }
    public void AddPoint()
    {
        if (points >= maxVal)
        {
            return;
        }
        this.points++;
        this.CalculateStat();
    }
}
