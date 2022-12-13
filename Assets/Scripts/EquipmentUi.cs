using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EquipmentUi : MonoBehaviour
{
    Equipment[] currEquip;
    EquipSlot[] EquipSlots;
    EquipmentManager eqMan;
    [SerializeField]
    Transform parent;
    [SerializeField]
    UnityEvent uiUpdatedCallback;
    // Start is called before the first frame update
    void Start()
    {
        eqMan = EquipmentManager.Instance;
        eqMan.onEquipChanged += UpdateUi;
        EquipSlots = parent.GetComponentsInChildren<EquipSlot>();
    }

    void UpdateUi(Equipment newE, Equipment oldE)
    {
        currEquip = eqMan.currEquip;
        //foreach (Equipment equip in currEquip)
        //{
        //    //TODO: predat equip equipslotu na spravnem enumu

        //}
        foreach (EquipSlot item in EquipSlots)
        {
            item.equipment = currEquip[(int)item.ESlot];
            Debug.Log((int)item.ESlot);
            Debug.Log(currEquip[(int)item.ESlot]);
            Debug.Log(currEquip[1]);
        }
        uiUpdatedCallback.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
