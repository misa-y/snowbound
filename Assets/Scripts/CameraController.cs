using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
 // Reference to the player GameObject.
 public GameObject player;

 // The distance between the camera and the player.
 private Vector3 offset;

// to access the player's movement input for camera rotation
private PlayerController playerController;

// Stores left/right input for camera rotation.
 private float rotationInput;

// Speed at which the camera rotates around the player.
 public float rotationSpeed = 90f; 

// Checks game over
 private bool GameOver = false;

// Stores platform position
 public Transform platform;

 // Start is called before the first frame update.
 void Start()
    {
 // Calculate the initial offset between the camera's position and the player's position.
        offset = transform.position - player.transform.position; 

        playerController = player.GetComponent<PlayerController>();
    }

 // LateUpdate is called once per frame after all Update functions have been completed.
 void LateUpdate()    
    {
      // if game over = trigger game over view (look up at platform)
      if (GameOver)
      {
         transform.LookAt(platform);
         return;
      }

      // if player object is destroyed, exit the function to avoid null reference errors
      if (player == null)
      {
         return;
      }

 // Maintain the same offset between the camera and player throughout the game.
        transform.position = player.transform.position + offset;  
        
       rotationInput = playerController.GetMovementX();
       
 // Rotate the camera around the player based on the left/right input.
        transform.RotateAround(player.transform.position, Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);

 // update the offset after rotating so the new camera angle is preserved
        offset = transform.position - player.transform.position;
    }

 public void GameOverView(Vector3 deathPosition, bool IcicleDeath)
 {
   GameOver = true;

   if(!IcicleDeath)
   {
   transform.position = deathPosition;
   }
   
 }
}

//NOTE: accidentally worked on my cameracontroller script for snowbound on my rollaball project, copy pasted both to swap