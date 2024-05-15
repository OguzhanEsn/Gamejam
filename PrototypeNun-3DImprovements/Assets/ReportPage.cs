using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportPage : MonoBehaviour
{
    [SerializeField] HudHandler hudHandler;

    public Transform playerLeftHand;
    public Transform reportParent;

    public Animator a;

    private MeshRenderer meshRenderer;

    public bool UIenabled;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();    
    }

    public void PickUp()
    {
        if (ReportInteract.isPickedUp)
        {

            transform.parent = playerLeftHand;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            //çok bok bi çözüm vv

            //report.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(ReportInteract.isPickedUp) 
        {
            if(Input.GetKeyDown(KeyCode.Tab)) 
            {
                EnableUI();

                if(gameObject.GetComponent<MeshRenderer>().enabled)
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                else
                    gameObject.GetComponent<MeshRenderer>().enabled = true;

            }
        }
    }

    public void EnableUI() 
    {
        hudHandler.RaporUIOpenClose();
        Debug.Log("123");
    }
}
