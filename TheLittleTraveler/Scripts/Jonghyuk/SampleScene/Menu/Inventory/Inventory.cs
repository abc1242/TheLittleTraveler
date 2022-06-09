using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static bool inventoryActivated = false;

    public GameObject MenuBack;
    // ÇÊ¿äÇÑ ÄÄÆ÷³ÍÆ®
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotsParent;

    // ½½·Ôµé.
    private Slot[] slots;


    // Use this for initialization
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        TryOpenInventory();
        if (GameManager.InvenOpen)
        {
            CloseInventory();
            GameManager.InvenOpen = false;
        }
    }

    public void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (MenuBack.activeSelf)
            {
                return;
            }
            else
            {
                Debug.Log(inventoryActivated);
                inventoryActivated = !inventoryActivated;
                if (inventoryActivated)
                    CloseInventory();
                else
                    OpenInventory();
            }
        }
    }

    public void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    public void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }
    public void B612ClearSlot()
    {
        for(int i = 0; i <slots.Length; i++ )
        {
            slots[i].item = null;
            slots[i].itemCount = 0;
            slots[i].itemImage.sprite = null;
        }
    }

    public void AcquireItem(AirportItem _item, int _count = 1)
    {
        if (AirportItem.ItemType.Equipment != _item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }
}
