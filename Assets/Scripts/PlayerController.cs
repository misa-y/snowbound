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

      // Apply force to the Rigidbody to move the player.
       rb.AddForce(movement * speed); 

      // Update the score based on time survived
       score += Time.deltaTime;
       SetScore();
       }

 private void OnTriggerEnter(Collider other)
       {
        if (other.gameObject.name == "DeathZone" || other.gameObject.name == "Icicle(Clone)")
              {

              bool IcicleDeath = other.gameObject.name == "Icicle(Clone)"; // Check if the player died from an icicle
              
              // trigger gameoverview
              Camera.main.GetComponent<CameraController>().GameOverView(transform.position, IcicleDeath);
              
              // Destroy the player object 
              Destroy(gameObject);
              // Display gameover text and playagain button
              gameOverText.SetActive(true);
              playAgainButton.SetActive(true);

              }
       }

 // Function to update score
 void SetScore() 
    {
        ScoreCount.text = "Score: " + score.ToString("F2"); // Display score with 2 decimal places
    }      
}