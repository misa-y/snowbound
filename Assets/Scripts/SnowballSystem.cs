using UnityEngine;

public class SnowballSystem : MonoBehaviour
{
    private float speed = 5f;
    private float rollSpeed = 200f; 

    public Transform snowballVisual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move straight across the platform
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        snowballVisual.Rotate(Vector3.forward * rollSpeed * Time.deltaTime); // snowball is rolling as it moves
    }
}
