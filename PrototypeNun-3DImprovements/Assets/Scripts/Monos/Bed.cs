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
    int CurrentHour()
    {
        Clock clock = FindObjectOfType<Clock>();
        int currentHour = clock.GetCurrentHour();

        return currentHour;
    }

    public void Interact()
    {
        int currentHour = CurrentHour();
        Debug.Log("Current Hour: " + currentHour);

        if(currentHour >= 17)
        {
            WorldSetUpGameManager.instance.DayPast();
        }
        //Check The Time Before That 

    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerController = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
