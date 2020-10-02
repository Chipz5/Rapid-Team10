using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TouchDetector : MonoBehaviour
{
    public GameObject particle;
    public Text test;
    int count = 5;
    void start()
    {
        test.text = "Tap on the screen 5 times exactly!";
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {

            if(count == 0)
            {
                test.text = "DO NOT TAP ANYMORE!!!!";
                count = 5;
            }
            else
            {
                test.text = "Tap " + count + " more times!";
                count--;
            }
            print("Tap detected...");
            
            
        }


    }






}
