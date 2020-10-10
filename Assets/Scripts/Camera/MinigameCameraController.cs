using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameState gameState = GameState.instance;
        transform.position = gameState.playerCamera.transform.position;
        transform.rotation = gameState.playerCamera.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
