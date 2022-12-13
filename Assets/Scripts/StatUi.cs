using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatUi : MonoBehaviour
{
    [SerializeField]
    List<TMP_Text> textList;
    [SerializeField]
    TMP_Text expDis;
    [SerializeField]
    GameObject parentGO;
    [SerializeField]
    KeyCode bindKey;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUi();
        EquipmentManager.Instance.onEquipChangedZ += UpdateUi;
        parentGO.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(bindKey))
        {
            parentGO.SetActive(!parentGO.activeSelf);
        }
    }

    public void UpdateUi()
    {
        expDis.text = StatManager.Instance.statPoints.ToString();
        textList.ForEach(item => Debug.Log(this));
        for (int i = 0; i < textList.Count; i++)
        {
            textList[i].text = StatManager.Instance.stats[i].type + ": " + StatManager.Instance.stats[i].currVal.ToString() + "\n + " + getModifiers(StatManager.Instance.stats[i].type);
            Debug.Log(textList[i].text);
        }
    }

    private string getModifiers(string statType)
    {
        int sum = 0;
        foreach (Equipment equip in EquipmentManager.Instance.currEquip)
        {
            if (equip != null)
            {
                if (statType == "ARM")
                {
                    sum += equip.defenseModifier;
                }
                if (statType == "DMG")
                {
                    sum += equip.damageModifier;
                }
            }
        }
        return sum.ToString();
    }
}
