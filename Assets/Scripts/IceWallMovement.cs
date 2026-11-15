using UnityEngine;

public class IceWallMovement : MonoBehaviour
{
    public int direction = 1;

    private float speed = 6f;
    private float distance = 14f;
    private Vector3 startPosition;
    private bool active = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.localPosition;
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        Invoke("ActivateIceWall", Random.Range(5f, 20f));
    }

    void Update()
    {   
        if (active)
        {
        transform.Translate(Vector3.forward * direction * speed * Time.deltaTime);
            
            if (Vector3.Distance(startPosition, transform.localPosition) >= distance)
            {
            direction *= -1;
            startPosition = transform.localPosition;
            }
        }
    }

    void ActivateIceWall()
    {
        GetComponent<Collider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
        active = true;

        Invoke("DeactivateIceWall", 15f); // obstacle is active for 15 seconds before deactivating
    }

    void DeactivateIceWall()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        active = false;

        Invoke("ActivateIceWall", Random.Range(10f, 25f));
    }
}
