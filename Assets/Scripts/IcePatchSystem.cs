using UnityEngine;

public class IcePatchSystem : MonoBehaviour
{
    private float normalDamping;

    void Start()
    {
        gameObject.SetActive(false);
        Invoke("ActivateIcePatch", 5f); 
    }

    //delay icepatch obstacle by 5 seconds
    private void ActivateIcePatch()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if(rb!= null){
                normalDamping = rb.linearDamping;

                rb.linearDamping = 0.075f; // set linear dampening to a lower value for sliding ice effect
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if(rb!= null){
                rb.linearDamping = normalDamping; // restore original linear dampening value
            }
        }
    }

}
