using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    Inventory inv;
    [SerializeField]
    KeyCode inventoryKey;
    InventorySlot[] slots;
    [SerializeField]
    Transform parent;
    [SerializeField]
    GameObject uiObject;
    [SerializeField]
    GameObject eUiObject;

    // Start is called before the first frame update
    void Start()
    {
        inv = Inventory.Instance;
        inv.onItemChangeCallback += UpdateUi;
        slots = parent.GetComponentsInChildren<InventorySlot>();
        eUiObject.SetActive(false);
        uiObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            uiObject.SetActive(!uiObject.activeSelf); //nastavuje vlastnost active gameobjectu uiObject na opaènou hodnotu
            eUiObject.SetActive(!eUiObject.activeSelf);
        }
    }

    void UpdateUi()
    {
        //Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.Instance.items.Count)
            {
                slots[i].InsertItem(Inventory.Instance.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }

        }
    }
}
