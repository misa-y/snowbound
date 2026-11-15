using UnityEngine;

public class SnowballMovement : MonoBehaviour
{
    private float speed = 6f;
    private float rollSpeed = 200f; 
    
    public Vector3 moveDirection;

    public Transform snowballVisual;

    // Update is called once per frame
    void Update()
    {
        //move straight across the platform
        transform.Translate(moveDirection * speed * Time.deltaTime);

        //rolls depend on movement direction
        
        if (moveDirection.x != 0)
            snowballVisual.Rotate(Vector3.forward*-moveDirection.x * rollSpeed * Time.deltaTime); // snowball is rolling as it moves
        else if (moveDirection.z != 0) 
            snowballVisual.Rotate(Vector3.right * moveDirection.z * rollSpeed * Time.deltaTime); // snowball is rolling as it moves
    }
}
