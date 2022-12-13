using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange = false;
    [SerializeField]
    KeyCode interactKey;
    [SerializeField]
    Item item;
    //[SerializeField]
    //UnityEvent interactAction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                //interactAction.Invoke();
                //Debug.Log(item.name);
                if(Inventory.Instance.AddItem(item))
                    Destroy(transform.parent.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("De�o aka Hr�� je InRange");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("De�o aka Hr�� nen� InRange");
        }
    }
}
