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

    public void CalculateStat()
    {
        this.currVal = this.baseVal += this.baseVal * this.points;
    }
    public void AddPoint(string type)
    {
        this.points++;
        this.CalculateStat();
    }
}
