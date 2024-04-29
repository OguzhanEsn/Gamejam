using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    public Animator animator; 
    private bool isFilling; 
    private float fillAmount; 

    private void Start()
    {
        StartFilling();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isFilling)
        {
            
            animator.SetBool("Fill", false);

            
            float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            fillAmount = CalculateApproximateFillAmount(normalizedTime);

            
            Debug.Log(fillAmount + " mg kadar zehir dolduruldu.");

            
            isFilling = false;
        }

        if(isFilling)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                isFilling = false;
                animator.SetBool("Fill", false);
                fillAmount = 10;
                Debug.Log(fillAmount + " mg kadar zehir dolduruldu.");
            }
           
        }
    }

    
    private float CalculateApproximateFillAmount(float normalizedTime)
    {
        
        float maxFillAmount = 10.0f;
        return normalizedTime * maxFillAmount;
    }

    
    public void StartFilling()
    {
        isFilling = true;
    }
}
