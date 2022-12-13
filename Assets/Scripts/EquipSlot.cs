using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    public Equipment equipment;
    [SerializeField]
    Image ico;
    [SerializeField]
    public ESlot ESlot;

    public void UpdateGraphics()
    {
        //ico.enabled = true;
        if (equipment != null)
        {
            ico.sprite = equipment.icon;
            ico.enabled = true;
        }
    }
}
