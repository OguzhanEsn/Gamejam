using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sink : MonoBehaviour, IInteractable
{
    [SerializeField] Interactions inter;

    [SerializeField] HudHandler hudHandler; //Testing

    [SerializeField] public InventoryHandler inventoryHandler;

    [SerializeField] ItemSO itemData;

    public new ParticleSystem particleSystem;

    public Material cleanScalpelMat;

    public PlayerController playerController;

    public void Interact()
    {
        switch(inter) {

            case SinkInteract sinkInteract:
                particleSystem.Play();
                if(inventoryHandler.GetCurrentItem() != null)
                {
                    if(inventoryHandler.HasKnife())
                    {
                        WeaponITSO scalpel = inventoryHandler.GetCurrentItem() as WeaponITSO;

                        if(scalpel != null)
                        {
                            if (scalpel.isBloody)
                            {
                                playerController.ChangeMaterial(cleanScalpelMat);
                            }
                        }

                    }
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
}
