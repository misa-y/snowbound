using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Vector3 rotationDirection = new Vector3(1, 0, 0);
    private float rotationSpeed = 2.5f;

    // changes direction every 15 seconds
    void Start()
    {
        InvokeRepeating("ChangeDirection", 5f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        // 4 tiers of difficulty, 0-30 sec, 30-60 sec, 60-90 sec, 90+ sec

        if (Time.timeSinceLevelLoad < 30f)
        {
            rotationSpeed = 2.5f; 
        }
        else if (Time.timeSinceLevelLoad < 60f)
        {
            rotationSpeed = 3.5f;
        }
        else if (Time.timeSinceLevelLoad < 90f)
        {
            rotationSpeed = 4.5f;
        }
        else
        {
            rotationSpeed = 5f;
        }

        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime, Space.World); //makes sure its the fixed x and z axis

    }

    //randomzies direction
    void ChangeDirection()
    {
        rotationDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        rotationDirection.Normalize(); // Normalize to ensure consistent rotation speed
    }
}
