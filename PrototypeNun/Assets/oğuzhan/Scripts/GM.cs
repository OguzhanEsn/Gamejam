using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class GM : MonoBehaviour
{

    public GameObject angelStatue;

    public GameObject letters;

    public static GM gm;

    public int currentScore;
    public int scorePerLetter = 100;

    public int currentMultiplier;
    public int multiplierTracker;
    public int hitTracker;
    public int[] multiplierThresholds;

    public bool failed, succeed;

    public TextMeshProUGUI txt;

    void Start()
    {
        gm = this;

        currentMultiplier = 1;
    }

  
    public void Hit()
    {
        hitTracker++;

        if(currentMultiplier - 1 < multiplierThresholds.Length)
        { 
            multiplierTracker++;

            if(multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        currentScore += scorePerLetter * currentMultiplier;

    }

    public void Miss()
    {

        currentMultiplier = 1;
        multiplierTracker = 0;


    }

    public void EndPrayMiniGame()
    {
        if(succeed) 
        {
            txt.text = "Succees";
        }
        if(failed)
        {
            txt.text = "Fail";
        }

        Animator a = angelStatue.GetComponent<Animator>();
        a.Play("PrayText");

        Statue s = a.GetComponent<Statue>();
        s.enabled = false;

        
    }

    

}
