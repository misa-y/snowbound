using UnityEngine;

public class CandyCaneSystem : MonoBehaviour
{
    private float activeTime = 15f; 
    private bool active = false;
    public float spinSpeed = 80f; // speed of candycane spin
    public Collider caneCollider;
    public GameObject curvedCaneColliders; // reference to the curved colliders of the candycane
    public MeshRenderer caneRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      // makes candycane invisible and non-collidable at the start of the game
        caneCollider.enabled = false;
        curvedCaneColliders.SetActive(false);
        caneRenderer.enabled = false;

        Invoke("ActivateCandyCane", Random.Range(1f, 2f)); //delay first activation of candycane obstacle by 15-25 seconds 
    }

    void Update()
    {
        if (active)
        {
            // Rotate the candycane when active
            transform.Rotate(spinSpeed * Time.deltaTime, 0, 0);
        }
    }

    // Spin the candycane
    private void ActivateCandyCane()
    {
        Debug.Log("CANDY CANE ACTIVATED");
        // turns on candycane obstacle
        active = true;
        caneCollider.enabled = true;
        curvedCaneColliders.SetActive(true);
        caneRenderer.enabled = true;

        // after activeTime seconds, deactivate candycane
        Invoke("DeActivateCandyCane", activeTime);
    }

    private void DeActivateCandyCane()
    {
        active = false;
        caneCollider.enabled = false;
        curvedCaneColliders.SetActive(false);
        caneRenderer.enabled = false;
        
        //randomly activate again (after candycane despawn) between 10-20 seconds
        Invoke("ActivateCandyCane", Random.Range(10f,20f));
    }
}
