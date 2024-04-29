using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField] private Interactions inter;
    [SerializeField] private HudHandler hudHandler;



    #region  IInteractable
    public void Activate()
    {
        inter.ShowInteractUI(this.gameObject, hudHandler);
    }

    public void DeInteract()
    {
        if(this == null) return;    
        //
        if(this.gameObject == null) return;

        inter.Deactivate(this.gameObject, hudHandler);
    }

    public void Interact()
    {
        //Check The Time Before That 
        WorldSetUpGameManager.instance.DayPast();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
