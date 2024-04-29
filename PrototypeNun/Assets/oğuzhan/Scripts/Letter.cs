using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{

    public bool canBePressed;

    public KeyCode key;

    //public GameObject hitEffect, missEffect;


    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                GM.gm.Hit();
                //GameObject go = Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Activator"))
        {
            canBePressed = true;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator") && gameObject.activeSelf)
        {
            canBePressed = false;

            GM.gm.Miss();
            //GameObject go = Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            Destroy(gameObject);
        }
    }
}
