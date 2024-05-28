using System.Collections;
using System.Collections.Generic;
using TestProp;
using Unity.VisualScripting;
using UnityEngine;

public class DailyRoutine : MonoBehaviour
{

    private void Update()
    {
        if(gameObject.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
            }
        }
    }

}
