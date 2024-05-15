using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSetUpGameManager : MonoBehaviour
{
    public static WorldSetUpGameManager instance;

    public int Loyalty = 7;
    public int Suspicion = 4;

    public int Day = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckWinLoseCond()
    {
        Debug.Log("Checking Win Lose Conditions" );
        Debug.Log("Suspicion: " + Suspicion);
        Debug.Log("Loyalty: " + Loyalty);
        if(Loyalty >= 10)
        {
            Loyalty = 10;
           // Debug.Log("You Win");
        }
        
        if(Suspicion >= 10 || Loyalty <= 0)
        {
            Debug.Log("You Lose");
            return;
        }else if(Day >= 5)
        {
            Debug.Log("You Win");
            return;
        }
    }


    [ContextMenu("SetUpWorld")]
    public void DayPast()
    {
        Patient[] patients = FindObjectsOfType<Patient>(); // Tüm Patient nesnelerini bul
        bool hasComplaint = false;
        
        foreach (Patient patient in patients)
        {
            if(patient.IsMurdered)
            {
                Suspicion += 4;
                patient.SetDeath();
                continue;
            }else if(patient.IsDead || patient.IsCrazy)
            {
                Loyalty ++;
                patient.SetDeath();
                continue;
            }else if(patient.hasComplain)
            {
                hasComplaint = true;
            }

            patient.SetDayBools(); // Her bir Patient nesnesinin SetDay metodunu çağır
        }

        if(hasComplaint)
        {
            Suspicion += 1;
        }else {Loyalty += 1;}
    
        CheckWinLoseCond();
        Debug.Log("Setting up the world");
    }
}
