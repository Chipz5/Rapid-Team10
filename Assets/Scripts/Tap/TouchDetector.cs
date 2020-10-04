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
    public GameObject closeSprite;
    void Awake()
    {
        test.text = "Tap on the screen 5 times exactly!";
        closeSprite = GameObject.Find("CloseOption");
        closeSprite.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Vector3 tapPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 tapPos2D = new Vector2(tapPos.x, tapPos.y);
            RaycastHit2D hit = Physics2D.Raycast(tapPos2D, Vector2.zero);
            //Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            print(Input.GetTouch(0).position);
            print(closeSprite.transform.position);
            
            print(closeSprite.transform.name);
            print(hit);
            //RaycastHit raycastHit;
            //print(Physics.Raycast(raycast, out raycastHit));
            if (hit.collider != null)
            {
                print("Something was hit!");
            }
            /*if (Physics.Raycast(raycast, out raycastHit))
            {
                print(raycastHit.transform.name);
                print("Something Hit");
                if (raycastHit.transform.name == "CloseOption")
                {
                    print("Close clicked");
                }

            }*/
            /* if(count == 0)
             {
                 test.text = "DO NOT TAP ANYMORE!!!!";
                 count = 5;
                 closeSprite.SetActive(true);
                 Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                 RaycastHit raycastHit;
                 if (Physics.Raycast(raycast, out raycastHit))
                 {
                     print("Something Hit");
                     if (raycastHit.collider.name == "CloseOption")
                     {
                         print("Close clicked");
                     }

                 }
                 //SceneManager.LoadScene(sceneName: "SwipeScene");
             }
             else
             {
                 //closeSprite.SetActive(false);
                 test.text = "Tap " + count + " more times!";
                 count--;
             }
             print("Tap detected...");*/


        }


    }






}
