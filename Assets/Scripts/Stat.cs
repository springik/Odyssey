using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
[System.Serializable]
public class Stat
{
    [SerializeField]
    public string type;
    [SerializeField]
    int baseVal;
    public int points { get; private set; } = 0;

    List<int> mods = new List<int>();
    public void addPoint()
    {
        points++;
    }
    public int GetTotalValue()
    {
        int temp = baseVal + points;
        mods.ForEach(item => temp += item);
        return temp;
    }
    public void addMod(int mod)
    {
        if (mod != 0)
            mods.Add(mod);
    }
    public void removeMod(int mod)
    {
        if(mod != 0)
            mods.Remove(mod);
    }
}
