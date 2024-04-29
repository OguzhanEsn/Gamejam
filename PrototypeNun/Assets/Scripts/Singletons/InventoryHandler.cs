using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public int maxStackSize = 8;
    public UiItemSlot[] itemSlots;
    public UiItem uiItemPrefab;

     //test
     public bool fakeItem = true;
    [SerializeField] GameObject fakeCurrentItem;
    [SerializeField] GameObject backPack;
    int selectedSlotIndex = -1;

    void Start()
    {
        //selectedSlotIndex = 0;
        //itemSlots[selectedSlotIndex].Select();
    }

    public void ChangeSelectedSlot(int newIndex)
    {
        if(selectedSlotIndex >= 0)
        {
            itemSlots[selectedSlotIndex].Deselect();
        }

        selectedSlotIndex += newIndex;
        if(selectedSlotIndex < 0)
        {
            selectedSlotIndex = 7;
        }
        else if(selectedSlotIndex > 7)
        {
            selectedSlotIndex = 0;
        }


        itemSlots[selectedSlotIndex].Select();
        GetCurrentItem();
    }


    public Item FakeCurrentItem()
    {
        return fakeCurrentItem.GetComponent<Item>();
    }

    public int GetCurrentItemNumber()
    {
        UiItem item = itemSlots[selectedSlotIndex].GetComponentInChildren<UiItem>();
        if(item == null)
        {
            return 0;
        }
        return item.itemCount;
    }

    public ItemSO GetCurrentItem()
    {
        //Debug.Log("SelectedSlotIndex: " + selectedSlotIndex);
        if(selectedSlotIndex < 0 || itemSlots[selectedSlotIndex].GetComponentInChildren<UiItem>() == null)
        {
            return null;
        }

        return itemSlots[selectedSlotIndex].GetComponentInChildren<UiItem>().itemData;
    }

    public void RemoveItem()
    {
        if(selectedSlotIndex < 0 || itemSlots[selectedSlotIndex].GetComponentInChildren<UiItem>() == null)
        {
            return;
        }

        UiItem item = itemSlots[selectedSlotIndex].GetComponentInChildren<UiItem>();
        if(item.itemCount > 1)
        {
            item.itemCount --;
            item.RefreshCount();
            //StackedItemRemoved
        }
        else
        {
            Destroy(item.gameObject);
            if(selectedSlotIndex == 0) 
            {
                itemSlots[selectedSlotIndex].Deselect();
                selectedSlotIndex = -1;
                return;
            }


            ChangeSelectedSlot(-1);
        }
    }

    public bool AddItem(ItemSO item)
    {
        // Add item to inventory
        //Find empty slot
        for(int i = 0; i < itemSlots.Length; i++)
        {
            UiItemSlot slot = itemSlots[i];
            UiItem itemInSlot = slot.GetComponentInChildren<UiItem>();
            if(itemInSlot == null)
            {
                // Slot is empty
               // itemInSlot.itemCount = 1 ;
                SpawnNewItem(item, slot);
                ChangeSelectedSlot(1);
                return true;
            } //CheckBelowLater
            else if(itemInSlot.itemData.itemID == item.itemID && item.isStackable && 
            itemInSlot.itemCount < maxStackSize)
            {
                //StackOption
                itemInSlot.itemCount ++;
                itemInSlot.RefreshCount();
                //SpawnNewItem(item, slot); 
                //We dont need to spawn item that already exists
                
                return true;
            }
        }
        return false;
    }

    void SpawnNewItem(ItemSO item, UiItemSlot slot)
    {
       // Debug.Log("Spawning new item");
        //Debug.Log("ITEMSO: " + item.itemName + " SLOT: " + slot);
        // Spawn item in the world
        //GameObject itemGO = Instantiate(item.itemPrefab, slot.transform);
        GameObject itemGO = Instantiate(uiItemPrefab.gameObject, slot.transform);
        //itemGO.GetComponent<UiItem>().itemData = item;
        //itemGO.GetComponent<UiItem>().SetItem(item);
        UiItem uiItem = itemGO.GetComponent<UiItem>();
        uiItem.SetItem(item);
    }



}
