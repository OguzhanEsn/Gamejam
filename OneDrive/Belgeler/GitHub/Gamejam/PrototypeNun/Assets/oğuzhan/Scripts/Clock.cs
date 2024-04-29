using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Clock : MonoBehaviour
{
    const float realSecondsPerIngameDay = 600f;

    Transform hourHand;
    Transform minuteHand;
    TMP_Text timeText;
    float day = 0.58f;

    private void Awake()
    {
        hourHand = transform.Find("hourHand");
        minuteHand = transform.Find("minuteHand");
        timeText = transform.Find("timeText").GetComponent<TextMeshProUGUI>();
    }
 
    
    void Update()
    {
        day += Time.deltaTime / realSecondsPerIngameDay;

        float dayNormalized = day % 1f;

        float rotationDegreesPerDay = 360f;
        hourHand.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);

        float hoursPerDay = 12f;
        minuteHand.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);


        string hour = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");
        string minutes = Mathf.Floor((((dayNormalized * hoursPerDay) % 1f) * 60f)).ToString("00");

        timeText.text = hour + ":" + minutes;

    }
}
