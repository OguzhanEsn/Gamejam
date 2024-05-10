using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buttons : MonoBehaviour
{

    Image sr;

    public Image img;
    public Image pressedImg;

    public KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(key))
            sr = pressedImg;

        if (Input.GetKeyUp(key))
            sr = img;

    }
}
