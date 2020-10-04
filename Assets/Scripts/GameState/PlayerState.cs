using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    [Tooltip("The camera prepresenting the players view (should be a child of the this game object)")]
    public Camera playerCamera;

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
}
