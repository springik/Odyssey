using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    public Stat hp;
    public int maxHp;
    public int currHp { get; private set; }
    public Stat dmg;
    public Stat def;
    public UnityAction onStatChanged;
    protected List<Stat> stats;

    private void Awake()
    {
        currHp = maxHp;
        stats = new List<Stat> { hp, dmg, def };
    }

    public void takeDamage(int amount)
    {
        amount -= def.GetTotalValue();
        amount = Mathf.Clamp(amount, 0, int.MaxValue);
        currHp -= amount;
        onStatChanged.Invoke();
        //Debug.Log("dmg taken log | name:" + transform.name);

        if (currHp <= 0)
        {
            die();
        }
    }

    protected virtual void die()
    {
        Debug.Log(transform.name + "dies");
    }
}
