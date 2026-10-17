using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Vector3 rotationDirection = new Vector3(1, 0, 0);

    // changes direction every 15 seconds
    void Start()
    {
        InvokeRepeating("ChangeDirection", 5f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationDirection * 4f * Time.deltaTime, Space.World); //makes sure its the fixed x and z axis

    }

    //randomzies direction
    void ChangeDirection()
    {
        rotationDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        rotationDirection.Normalize(); // Normalize to ensure consistent rotation speed
    }
}
