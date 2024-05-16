using MiniGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour, IInteractable
{
    [SerializeField] private Interactions inter;
    [SerializeField] private HudHandler hudHandler;

    [SerializeField] InventoryHandler inventoryHandler;


    #region  IInteractable
    public void Activate()
    {

    }

    public void DeInteract()
    {
        if (this == null) return;
        //
        if (this.gameObject == null) return;

        inter.Deactivate(this.gameObject, hudHandler);
    }
    public void Interact()
    {


    }

    #endregion
    public void CloseUI()
    {
        hudHandler.CloseMiniGameUI();
    }
}
