using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    #region SingleInv
    public static Inventory Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("V�ce instanc� Inventory a to je velk� �patn�");
            return;
        }
        Instance = this;
    }

    #endregion
    public int space = 12;
    public delegate void onItemChange();
    public onItemChange onItemChangeCallback;
    [SerializeField]
    public List<Item> items = new List<Item>();

    public bool AddItem(Item item)
    {
        if (!item.isDefault)
        {
            if (items.Count >= space)
            {
                Debug.Log("Nedostatek m�sta v invu!");
                return false;
            }
            items.Add(item);
            if(onItemChangeCallback != null)
                onItemChangeCallback.Invoke();
            return true;
        }
        return false;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        if(onItemChangeCallback != null)
            onItemChangeCallback.Invoke();
    }
}
