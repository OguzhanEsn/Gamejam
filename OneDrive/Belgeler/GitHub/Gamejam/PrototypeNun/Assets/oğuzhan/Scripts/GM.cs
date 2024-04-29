using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{


    public GameObject letters;

    public static GM gm;

    public int currentScore;
    public int scorePerLetter = 100;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;


    void Start()
    {
        gm = this;

        StartCoroutine(nameof(SpawnLetters));

        currentMultiplier = 1;
    }

  
    public void Hit()
    {

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


    IEnumerator SpawnLetters()
    {
        GameObject go = Instantiate(letters, letters.transform.position, letters.transform.rotation);
        go.transform.parent = transform;
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = new Vector3(0, 8, 0);

        yield return new WaitForSeconds(15f);

        StartCoroutine(nameof(SpawnLetters));
    }
}
