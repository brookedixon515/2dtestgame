using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public Item item;
    public GameObject meat;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
           GameObject.FindWithTag("InventoryManager").GetComponent<InventoryManager>().AddItem(item);
            meat.SetActive(false);
        }
    }
}
