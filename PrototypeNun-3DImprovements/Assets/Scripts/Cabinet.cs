using MiniGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class Cabinet : MonoBehaviour, IInteractable
{
    [SerializeField] private Interactions inter;
    [SerializeField] private HudHandler hudHandler;

    [SerializeField] Animator animator;
    public AudioSource asource;
    public AudioClip openDrawer, closeDrawer;

    public bool isOpen = false;

    #region IInteractable

    public void Activate()
    {
        inter.ShowInteractUI(this.gameObject, hudHandler);
    }

    public void Interact()
    {

    }

    public void DeInteract()
    {
        if (this == null) return;
        //
        if (this.gameObject == null) return;

        inter.Deactivate(this.gameObject, hudHandler);


    }
    #endregion


    public void OpenDrawer()
    {
        PlayOpenCloseAnim(isOpen);
        isOpen = !isOpen;
        asource.clip = isOpen ? openDrawer : closeDrawer;
        asource.Play();
    }

    public void PlayOpenCloseAnim(bool _isOpen)
    {
        if(!_isOpen)
        {
            animator.Play("DrugCabinetOpen");
        }else
        {
            animator.Play("DrugCabinetClose");
        }
    }


}
