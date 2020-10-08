using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [Header("The state of the player in the Movement scene")]
    [Tooltip("The position of the player in the Movement scene")]
    public Vector3 playerPosition;
    [Tooltip("The rotation of the player in the Movement scene")]
    public Quaternion playerRotation;
    [Tooltip("The rotation of the camera in the Movement scene")]
    public Quaternion cameraRotation;
    [Header("The player and camera objects controlled by the joysticks")]
    [Tooltip("The player representing the main character (must have a Rigidbody attached)")]
    public Rigidbody player;
    [Tooltip("The camera representing the main character's view (should be the child of player)")]
    public Camera playerCamera;

    public static string currentCollisionKey;

    private static bool firstInitializationComplete = false;

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

    // A dictionary storing the name of the gameobject that should trigger the corresponding task callbacks
    public static Dictionary<string, Task> taskList = new Dictionary<string, Task>();

    // Start is called before the first frame update
    void Start()
    {
        if(!firstInitializationComplete)
        {
            firstInitializationComplete = true;
            taskList.Add("Door", new Task("Leave your home.",
                ()=>
                {
                    // When the player contacts the door trying to leave, add new tasks for them to complete
                    taskList.Remove("Door");
                    taskList.Add("Stove", new Task("Check the stove.",
                        () =>
                        {
                            currentCollisionKey = "Stove";
                            // When the player contacts the stove, launch the minigame
                            SceneManager.LoadScene(sceneName: "TapAtSpecificPoint"); 
                        },
                        () =>
                        {
                            taskList.Remove("Stove");
                            IfAllMinigamesAreComplete();
                            SceneManager.LoadScene(sceneName: "Movement");
                        },
                        "Turn the stove on and off.",
                        5));
                    taskList.Add("Lamp", new Task("Check the lamp.",
                        () =>
                        {
                            currentCollisionKey = "Lamp";
                            // When the player contacts the stove, launch the minigame
                            SceneManager.LoadScene(sceneName: "SwipeScene");
                        },
                        () =>
                        {
                            taskList.Remove("Lamp");
                            IfAllMinigamesAreComplete();
                            SceneManager.LoadScene(sceneName: "Movement");
                        },
                        "Turn the lamp on and off.",
                        5));
                    // TODO: Add other tasks to the list here
                },
                ()=>
                {
                    return; // There is no minigame to complete, so this is not needed
                },
                "", 
                0));
        }
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

    private void IfAllMinigamesAreComplete()
    {
        if(taskList.Count == 0)
        {
            taskList.Add("Door", new Task("Leave your home.",
                         () =>
                         {
                             currentCollisionKey = "Door";
                             // When the player contacts the door, transition to the last minigame
                             SceneManager.LoadScene(sceneName: "TapScene");
                         },
                         () =>
                         {
                             taskList.Remove("Door");
                             SceneManager.LoadScene(sceneName: "WinScene");
                         },
                         "Lock and unlock the door.",
                         5));
        }
    }
}
