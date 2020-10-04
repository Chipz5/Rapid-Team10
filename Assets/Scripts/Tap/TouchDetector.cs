using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System.Collections.Specialized;

public class TouchDetector : MonoBehaviour
{
    public Text test;
    int count = 5;
    public GameObject button;
    void Awake()
    {
        test.text = "Tap on the screen 5 times exactly!";
        button = GameObject.Find("Button");
        button.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if( count == 6)
            {
                test.text = "You tapped too many times.... START AGAIN!!!!";
                count--;
            }
            else if (count == 0)
             {
                 test.text = "DO NOT TAP ANYMORE!!!!";
                 count = 6;
                button.SetActive(true);

            }
             else
             {
                button.SetActive(false);
                test.text = "Tap " + count + " more times!";
                
                count--;
                
                //button.SetActive(false);
            }
             print("Tap detected...");


        }


    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(sceneName: "Movement");
    }




}
