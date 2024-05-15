using MiniGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Interactions inter;
    [SerializeField] private HudHandler hudHandler;

    public bool canOpen = true;
    public bool isOpen = false;

    public Animator a;

    #region  IInteractable
    public void Activate()
    {
        inter.ShowInteractUI(this.gameObject, hudHandler);
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
