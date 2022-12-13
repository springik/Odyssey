using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image ico;
    public Button removeBtn;
    
    public void InsertItem(Item item)
    {
        this.item = item;
        ico.sprite = item.icon;
        ico.enabled = true;
        removeBtn.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        ico.sprite = null;
        ico.enabled = false;
        removeBtn.interactable = false;
    }

    public void OnTrash()
    {
        Inventory.Instance.RemoveItem(item);
    }

    public void OnUse()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
