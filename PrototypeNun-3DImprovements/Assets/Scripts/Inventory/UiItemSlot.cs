using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiItemSlot : MonoBehaviour,  IDropHandler
{
    public Image image;
    public Color vanillaColor, selectedColor;
    public ItemSO itemData;


    private void Awake()
    {
        Deselect();
    }
    public void Select()
    {
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = vanillaColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
       if(transform.childCount == 0)
       {
              UiItem item = eventData.pointerDrag.GetComponent<UiItem>();
              item.parentAfterDrag = transform;

       }
    }
}
