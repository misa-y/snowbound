using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
 // Rigidbody of the player.
 private Rigidbody rb; 

 // Movement along the X andY axes.
 private float movementX;
 private float movementY;

 // Speed at which the player moves.
 public float speed = 0; 

// Score count based on time, score text
 private float score = 0;
 public TextMeshProUGUI ScoreCount;

 // Game Over text and Play Again button
 public GameObject gameOverText;
 public GameObject playAgainButton;

// checks if player is on the IcePatch (to adjust the force applied, to make it harder to control the player on ice)
 public bool onIce = false;
 
 // for gameover views for differentobstacles
 private bool IcicleDeath = false;

// sound effects
 public AudioSource icicleSound;
 public AudioSource gameoverSound;

// so cameracontroller can access the player's movement input for camera rotation
public float GetMovementX()
       {
       return movementX;
       }

// Reference to the camera's transform for CameraController script so the player can move relative to the camera's direction.
public Transform cameraTransform;


 // Start is called before the first frame update.
 void Start()
       {
       // Get and store the Rigidbody component attached to the player.
       rb = GetComponent<Rigidbody>();
       gameOverText.SetActive(false);
       playAgainButton.SetActive(false);
       }
 
 // This function is called when a move input is detected.
 void OnMove(InputValue movementValue)
       {
       // Convert the input value into a Vector2 for movement.
       Vector2 movementVector = movementValue.Get<Vector2>();

       // Store the X and Y components of the movement.
       movementY = movementVector.y; 
       movementX = movementVector.x;
       }

 // FixedUpdate is called once per fixed frame-rate frame.
 void FixedUpdate() 
       {
      // Get the forward direction of the camera to move the player relative to the camera's orientation.
       Vector3 forward = cameraTransform.forward;      
       forward.y = 0; // Flatten the forward vector to ignore vertical movement. (since camera is angled downwards)
       forward.Normalize(); // Keep the movement direction at a consistent length.


      // Create a 3D movement vector based on the player's input and the camera's forward direction.
       Vector3 movement = forward * movementY;

      if (onIce)
      {
       // reduce the force applied to the player when on ice to make it harder to control
       rb.AddForce(movement * speed * 0.3f); 
      }
      
      else
      // Apply force to the Rigidbody to move the player, normal
       rb.AddForce(movement * speed); 

      // Update the score based on time survived
       score += Time.deltaTime;
       SetScore();
       }

 private void OnTriggerEnter(Collider other)
       {
            //reset death trigger
            IcicleDeath = false;
            
        if (other.gameObject.name == "Icicle(Clone)")
              {
              IcicleDeath = true; // Check if the player died from an icicle
              AudioSource.PlayClipAtPoint(icicleSound.clip, transform.position); // Play the icicle sound  (lets the sound play before destroying object)
              gameOver();
              }
       else if (other.gameObject.name == "DeathZone")
              {
              gameOver();
              }
       }

  private void gameOver(){
      // AudioSource.PlayClipAtPoint(gameoverSound.clip, transform.position); //play gameover sound for any death

      // trigger gameoverview
      Camera.main.GetComponent<CameraController>().GameOverView(transform.position, IcicleDeath);
              
      // Destroy the player object 
      //change color of player object to flash red before destroying it
      GetComponent<Renderer>().material.color = Color.red;
      
      Destroy(gameObject);
      // Display gameover text and playagain button
      gameOverText.SetActive(true);
      playAgainButton.SetActive(true);
  }

 // Function to update score
 void SetScore() 
    {
        ScoreCount.text = "Score: " + score.ToString("F2"); // Display score with 2 decimal places
    }      
}