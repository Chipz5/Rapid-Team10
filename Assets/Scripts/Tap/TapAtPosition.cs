using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapAtPosition : MonoBehaviour
{

    private GameObject circle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            circle = GameObject.Find("Circle");
            if (circle.transform.position.x > -1.25 && circle.transform.position.x < 1.25)
            {
                GameState.taskList[GameState.currentCollisionKey].onMinigameComplete();
            }
        }

        // DEBUG CODE: Shouldn't affect the mobile version though
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameState.taskList[GameState.currentCollisionKey].onMinigameComplete();
        }
    }
}
