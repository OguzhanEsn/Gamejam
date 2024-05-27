using System.Collections;
using System.Collections.Generic;
using TestProp;
using Unity.VisualScripting;
using UnityEngine;

public class DailyRoutine : MonoBehaviour
{

    [SerializeField] HudHandler hudHandler;
    [SerializeField] GameObject RoutineUI;
    [SerializeField] PlayerController playerController;



    public void RoutineUIOpenClose()
    {
        if (RoutineUI.activeSelf)
        {
            RoutineUI.SetActive(false);
        }
        else
        {
            RoutineUI.SetActive(true);
        }
    }

}
