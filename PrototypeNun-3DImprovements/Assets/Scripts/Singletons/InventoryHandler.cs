using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    public TextMeshProUGUI itemNameText;  // Reference to the Text element

    // Test


    void Start()
    {
        if (itemSlots.Length > 0)
        {
            selectedSlotIndex = 0;
            itemSlots[selectedSlotIndex].Select();
            UpdateItemNameText();
        }
    }

    void Update()
    {
        // Handle scroll wheel input for changing selected slot
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput > 0f)
        {
            ChangeSelectedSlotByOffset(1);  // Scroll up
        }
        else if (scrollInput < 0f)
        {
            ChangeSelectedSlotByOffset(-1); // Scroll down
        }

        // Other update logic here
    }

    public void ChangeSelectedSlotByOffset(int offset)
    {
        if (selectedSlotIndex >= 0)
        {
            itemSlots[selectedSlotIndex].Deselect();
        }

        selectedSlotIndex += offset;

        if (selectedSlotIndex < 0)
        {
            selectedSlotIndex = itemSlots.Length - 1;
        }
        else if (selectedSlotIndex >= itemSlots.Length)
        {
            selectedSlotIndex = 0;
        }

        itemSlots[selectedSlotIndex].Select();
        GetCurrentItem();
        UpdateItemNameText();
    }

    public void ChangeSelectedSlot(int newIndex)
    {
        if (selectedSlotIndex >= 0)
        {
            itemSlots[selectedSlotIndex].Deselect();
        }

        selectedSlotIndex = newIndex;

        if (selectedSlotIndex < 0)
        {
            selectedSlotIndex = itemSlots.Length - 1;
        }
        else if (selectedSlotIndex >= itemSlots.Length)
        {
            selectedSlotIndex = 0;
        }

        itemSlots[selectedSlotIndex].Select();
        GetCurrentItem();
        UpdateItemNameText();
    }

    public Item FakeCurrentItem()
    {
        return fakeCurrentItem.GetComponent<Item>();
    }

    public int GetCurrentItemNumber()
    {
        UiItem item = itemSlots[selectedSlotIndex].GetComponentInChildren<UiItem>();
        if (item == null)
        {
            return 0;
        }
        return item.itemCount;
    }

    public ItemSO GetCurrentItem()
    {
        if (selectedSlotIndex < 0 || itemSlots[selectedSlotIndex].GetComponentInChildren<UiItem>() == null)
        {
            return null;
        }

        return itemSlots[selectedSlotIndex].GetComponentInChildren<UiItem>().itemData;
    }

    public void RemoveItem()
    {
        if (selectedSlotIndex < 0 || itemSlots[selectedSlotIndex].GetComponentInChildren<UiItem>() == null)
        {
            return;
        }

        UiItem item = itemSlots[selectedSlotIndex].GetComponentInChildren<UiItem>();
        if (item.itemCount > 1)
        {
            item.itemCount--;
            item.RefreshCount();
        }
        else
        {
            Destroy(item.gameObject);
            if (selectedSlotIndex == 0)
            {
                itemSlots[selectedSlotIndex].Deselect();
                selectedSlotIndex = -1;
                itemNameText.text = ""; // Clear item name text when inventory is empty
                return;
            }

            ChangeSelectedSlotByOffset(-1);
        }
    }

    public bool AddItem(ItemSO item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            UiItemSlot slot = itemSlots[i];
            UiItem itemInSlot = slot.GetComponentInChildren<UiItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot, i);
                return true;
            }
            else if (itemInSlot.itemData.itemID == item.itemID && item.isStackable &&
                     itemInSlot.itemCount < maxStackSize)
            {
                itemInSlot.itemCount++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        return false;
    }

    void SpawnNewItem(ItemSO item, UiItemSlot slot, int slotIndex)
    {
        Debug.Log("Spawning new item");
        GameObject itemGO = Instantiate(uiItemPrefab.gameObject, slot.transform);
        UiItem uiItem = itemGO.GetComponent<UiItem>();
        uiItem.SetItem(item);

        // Set the selected slot to the one where the item was added
        ChangeSelectedSlot(slotIndex);
        UpdateItemNameText();
    }

    void UpdateItemNameText()
    {
        if (selectedSlotIndex >= 0)
        {
            UiItem uiItem = itemSlots[selectedSlotIndex].GetComponentInChildren<UiItem>();
            if (uiItem != null && uiItem.itemData != null)
            {
                itemNameText.text = uiItem.itemData.itemName;
                // Update the position of the itemNameText to be above the selected slot
                RectTransform slotRectTransform = itemSlots[selectedSlotIndex].GetComponent<RectTransform>();
                itemNameText.rectTransform.position = slotRectTransform.position + new Vector3(0, slotRectTransform.rect.height, 0);
            }
            else
            {
                itemNameText.text = "";
            }
        }
        else
        {
            itemNameText.text = "";
        }
    }

    public bool HasKnife()
    {
        foreach (UiItemSlot slot in itemSlots)
        {
            UiItem uiItem = slot.GetComponentInChildren<UiItem>();
            if (uiItem != null && uiItem.itemData != null)
            {

                if (uiItem.itemData.itemName == "Scalpel") 
                {
                    return true;
                }
            }
        }
        return false; 
    }

}
