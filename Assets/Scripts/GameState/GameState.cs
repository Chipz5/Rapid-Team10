using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [Header("The state of the player in the Movement scene")]
    [Tooltip("The position of the player in the Movement scene")]
    public Vector3 playerPosition;
    [Tooltip("The rotation of the player in the Movement scene")]
    public Quaternion playerRotation;
    [Tooltip("The rotation of the camera in the Movement scene")]
    public Quaternion cameraRotation;
    public Boolean shouldLaunchMiniTask = true;
    [Header("The player and camera objects controlled by the joysticks")]
    [Tooltip("The player representing the main character (must have a Rigidbody attached)")]
    public Rigidbody player;
    [Tooltip("The camera representing the main character's view (should be the child of player)")]
    public Camera playerCamera;

    // Create a singleton of this class, so that only one can ever exist
    private static GameState _instance;
    public static GameState instance
    {
        get
        {
            if(_instance == null)
            {
                // Create this object in the scene only once
                GameObject gameState = new GameObject("GameState");
                _instance = gameState.AddComponent<GameState>();
                // And make sure it is never destroyed
                DontDestroyOnLoad(gameState);
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If there is a player and camera in this scene
        if(player != null && playerCamera != null)
        {
            // Store their positions and rotations
            playerPosition = player.transform.position;
            playerRotation = player.transform.rotation;
            cameraRotation = playerCamera.transform.rotation;
        }
    }
}
