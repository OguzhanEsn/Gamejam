using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayRack : MonoBehaviour, IInteractable
{
    [SerializeField] Interactions inter;

    [SerializeField] HudHandler hudHandler; //Testing

    [SerializeField] public InventoryHandler inventoryHandler;


    public void Interact()
    {
        switch (inter)
        {

            case PushInteract foodTray:
                Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

                if(player != null )
                {
                    if (transform.parent == null)
                    {
                        gameObject.transform.parent = player;
                    }
                    else
                        transform.parent = null;
                }
                
                
            break;
        }
    }


    public void DeInteract()
    {
        if (this == null) return;
        //
        if (this.gameObject == null) return;

        inter.Deactivate(this.gameObject, hudHandler);

    }

    public void Activate()
    {
        //
        inter.ShowInteractUI(this.gameObject, hudHandler);
    }


    private void OnTransformParentChanged()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if(transform.parent == player)
        {

        }

    }
}
