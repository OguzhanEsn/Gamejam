using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour, IInteractable
{

    private bool hasPrayedToday = false;

    public bool HasPrayedToday
    {
        get { return hasPrayedToday; }
        set { hasPrayedToday = value; }
    }
    [SerializeField] Interactions inter;

    [SerializeField] HudHandler hudHandler; //Testing

    [SerializeField] InventoryHandler inventoryHandler;

    [SerializeField] ItemSO itemData;

    public ItemSO ItemData
    {
        get { return itemData; }
        set { itemData = value; }
    }



    public void Activate()
    {
        inter.ShowInteractUI(this.gameObject, hudHandler);
    }

    public void DeInteract()
    {
        inter.Deactivate(this.gameObject, hudHandler);
    }

    public void Interact()
    {
      switch(inter)
      {
        case PrayInteract prayInteract:

        if(!hasPrayedToday){
         //PrayMiniGameOpen
          Debug.Log("Praying");}
          break;
      }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
