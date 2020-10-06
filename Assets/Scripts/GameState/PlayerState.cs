using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{

    [Tooltip("The camera prepresenting the players view (should be a child of the this game object)")]
    public Camera playerCamera;
    //private Boolean shouldLaunchMiniTask = true;
    // Start is called before the first frame update
    void Start()
    {
        GameState gameState = GameState.instance;
        transform.position = gameState.playerPosition;
        transform.rotation = gameState.playerRotation;
        playerCamera.transform.rotation = gameState.cameraRotation;
        gameState.player = this.GetComponent<Rigidbody>();
        gameState.playerCamera = playerCamera;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision hit)
    {
        GameState gameState = GameState.instance;
        if (gameState.shouldLaunchMiniTask && hit.transform.gameObject.name == "Door")
        {
            gameState.shouldLaunchMiniTask = false;
            SceneManager.LoadScene(sceneName: "TapScene");
        }
    }
}
