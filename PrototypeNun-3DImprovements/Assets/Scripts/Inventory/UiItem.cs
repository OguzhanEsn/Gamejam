using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

 
public class UiItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerExitHandler 
{
    [Header("UI REFERENCES")]
    public Image itemImage;
    public TextMeshProUGUI itemCountText;

    [HideInInspector] public ItemSO itemData;
    [HideInInspector] public int itemCount= 1;

    [HideInInspector] public Transform parentAfterDrag;
    
    public void SetItem(ItemSO item)
    {
        itemData = item;
        itemImage.sprite = item.uiIcon;
        RefreshCount();
    }

    public void RefreshCount()
    {
        itemCountText.text = itemCount.ToString();
        bool isActive = itemCount > 1;
        itemCountText.gameObject.SetActive(isActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {  
        Debug.Log("BeginDrag");  
        itemImage.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        itemImage.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("PointerExitAAAAAAA");
    }
}
