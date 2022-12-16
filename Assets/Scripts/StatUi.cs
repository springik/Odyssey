using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Linq;
using UnityEngine.UIElements;

public class StatUI : MonoBehaviour
{
    [SerializeField]
    PlayerStats playerStats;
    List<StatParent> parents;
    [SerializeField]
    TMP_Text pointText;
    [SerializeField]
    GameObject panel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
            panel.SetActive(!panel.activeSelf);
    }
    private void Awake()
    {
        parents = GetComponentsInChildren<StatParent>().ToList<StatParent>();
        playerStats.onStatChanged += UpdateUi;
        playerStats.onLevelUp += UpdateUi;
        panel.SetActive(false);
    }

    void UpdateUi()
    {
        Stat stat;
        foreach (StatParent parent in parents)
        {
            stat = playerStats.findStat(parent.statType);
            parent.text.text = stat.type + ": " + stat.GetTotalValue();
        }
        pointText.text = playerStats.availablePoints.ToString();
    }

    public void addToStat(string type)
    {
        playerStats.addToStat(type);
        UpdateUi();
    }
}
