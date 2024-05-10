using MiniGames;
using System.Collections;
using System.Collections.Generic;
using TestProp;
using UnityEngine;

public class Statue : MonoBehaviour, IInteractable
{
    [SerializeField] private Interactions inter;
    [SerializeField] private HudHandler hudHandler;

    public bool hasPrayed = false;

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
        if (!hasPrayed)
        {
            switch (inter)
            {
                case PrayInteract prayInteract:

                    hudHandler.ActivateMiniGameUI(MiniGameType.Pray, LockDifficulty.Medium,
                        3, this.gameObject);

                    hasPrayed = true;
                    break;
            }
        }
        
    }

    #endregion
    public void CloseUI()
    {
        hudHandler.CloseMiniGameUI();
    }
}
