using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public item item;

    [Header("UI")]
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;

    private void Start()
    {
        InitialiseItem(item);
    }

    public void InitialiseItem(item newItem)
    {
        image.sprite = newItem.image;
    }
   
    public void OnBeginDrag(PointerEventData eventdata)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventdata)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventdata)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

}
