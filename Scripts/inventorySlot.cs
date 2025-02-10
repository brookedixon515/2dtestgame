using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class inventorySlot : MonoBehaviour, IDropHandler
{

  
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            inventoryItem InventoryItem = eventData.pointerDrag.GetComponent<inventoryItem>();
            InventoryItem.parentAfterDrag = transform;
        }
    }
  
}
