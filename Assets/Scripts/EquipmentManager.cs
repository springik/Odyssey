using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region singleton
    public static EquipmentManager Instance;

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

    public Equipment[] currEquip;
    Inventory inventory;
    public delegate void onEquipChange(Equipment newItem, Equipment oldItem);
    public onEquipChange onEquipChanged;
    //zero parameter callback
    public delegate void onEquipChangeZ();
    public onEquipChangeZ onEquipChangedZ;

    private void Start()
    {
        //string array enums v equipment
        int space = System.Enum.GetNames(typeof(ESlot)).Length;
        currEquip = new Equipment[space];
        inventory = Inventory.Instance;
    }

    public void Equip(Equipment equip)
    {
        Equipment oldItem = null;
        int slotIndex = (int)equip.equipmentSlot;
        if (currEquip[slotIndex] != null)
        {
            oldItem = currEquip[slotIndex];
            inventory.AddItem(oldItem);
        }
        currEquip[slotIndex] = equip;

        if (onEquipChanged != null)
        {
            onEquipChanged.Invoke(equip, oldItem);
            onEquipChangedZ.Invoke();
        }
    }
    public void Unequip(int slotIndex)
    {
        if (currEquip[slotIndex] != null)
        {
            Equipment oldItem = currEquip[slotIndex];
            inventory.AddItem(oldItem);
            currEquip[slotIndex] = null;
            if (onEquipChanged != null)
            {
                onEquipChanged.Invoke(null, oldItem);
                onEquipChangedZ.Invoke();
            }
        }
    }
}
