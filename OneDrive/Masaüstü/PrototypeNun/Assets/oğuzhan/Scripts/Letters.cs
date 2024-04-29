using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letters : MonoBehaviour
{

    public float speed;
    public float[] speedMultipliers;

    void Start()
    {

        RandomizeY();
    }

    void RandomizeY()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            float rand = Random.Range(-3, 3);
            if (rand == 0 || rand == 1)
                return;

            Vector3 randomY = new(0,Mathf.Ceil(rand),0);

            child.position += randomY;

        }
        
    }

    void Update()
    {

        switch(GM.gm.currentMultiplier)
        {
            case 1:
                transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
                break;
            case 2:
                transform.position -= new Vector3(0f, speed * Time.deltaTime * speedMultipliers[0], 0f);
                break;
            case 3:
                transform.position -= new Vector3(0f, speed * Time.deltaTime * speedMultipliers[1], 0f);
                break;
            case 4:
                transform.position -= new Vector3(0f, speed * Time.deltaTime * speedMultipliers[2], 0f);
                break;
        }

        if (transform.childCount == 0)
            Destroy(gameObject);

    }

    
}
