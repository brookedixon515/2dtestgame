using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager instance;
    public Item[] startItems;
    
    public int maxStackedItems = 64;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public BoxCollider2D hitbox;
    int selectedSlot = -1;

    private GameObject sword;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeSelectedSlot(0);
        foreach (var item in startItems)
        {
            AddItem(item);
        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeSelectedSlot(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeSelectedSlot(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeSelectedSlot(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeSelectedSlot(3);
        }
    
       
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        
        if (itemInSlot != null && itemInSlot.item.name == "Sword" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("attack done");
            Invoke("ActivateHitbox", 0.2f); 
            Invoke("DeactivateHitbox", 0.4f); 
        }

         if (itemInSlot != null && itemInSlot.item.name == "Pickaxe" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("mining done");
        }
    }
    
    void ActivateHitbox()
    {
        hitbox.gameObject.SetActive(true);
    }

    void DeactivateHitbox()
    {
        hitbox.gameObject.SetActive(false);
    }

    void ChangeSelectedSlot(int newValue)
    {
        if(selectedSlot >= 0)
        {
        inventorySlots[selectedSlot].Deselect();
        }

        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(Item item) 
    {
         for(int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }


        for(int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);

    } 

    public InventoryManager GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (use == true)
            {
                itemInSlot.count--;
                if(itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }
        }
        return null;
    }
}
    