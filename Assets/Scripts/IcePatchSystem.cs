using UnityEngine;

public class IcePatchSystem : MonoBehaviour
{
    private float normalDamping;
    private float activeTime = 20f; // time of ice patch activation
    
    public AudioSource icePatchSound;

    void Start()
    {
        // makes patch invisible and non-collidable at the start of the game
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        Invoke("ActivateIcePatch", Random.Range(15f, 25f)); //delay first activation of icepatch obstacle by 15-25 seconds
        
    }

    private void ActivateIcePatch()
    {
        // turns on ice patch obstacle
        GetComponent<Collider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;

        // after activeTime seconds, deactivate the ice patch
        Invoke("DeActivateIcePatch", activeTime);
    }

    private void DeActivateIcePatch()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        
        //randomly activate again (after ice patch despawn) between 10-25 seconds
        Invoke("ActivateIcePatch", Random.Range(10f,25f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if(rb!= null){
                normalDamping = rb.linearDamping;
                rb.linearDamping = 0.075f; // set linear dampening to a lower value for sliding ice effect
                rb.linearVelocity *= 2f; // increase the player's speed when on ice patch

                other.GetComponent<PlayerController>().onIce=true; //on the ice patch

                icePatchSound.Play(); // Play the ice patch sound when the player enters the ice patch
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if(rb!= null){
                rb.linearDamping = normalDamping; // restore original linear dampening value

                other.GetComponent<PlayerController>().onIce=false; //off the ice patch
            }
        }
    }

}
