using UnityEngine;

public class BlueFireSystem : MonoBehaviour
{
    private float activeTime = 20f; 
    public GameObject snowflake;
    public GameObject blueFire;
    public GameObject blueFireCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        snowflake.SetActive(false);
        blueFire.SetActive(false);
        blueFireCollider.SetActive(false);

        Invoke ("ActivateBlueFire", Random.Range(1f, 2f)); //delay first activation of bluefire obstacle by 5-20 seconds
    }

    private void ActivateBlueFire()
    {
        snowflake.SetActive(true);
        blueFire.SetActive(true);
        blueFireCollider.SetActive(true);

        // after activeTime seconds, deactivate candycane
        Invoke("DeActivateBlueFire", activeTime);
    }

    private void DeActivateBlueFire()
    {
        snowflake.SetActive(false);
        blueFire.SetActive(false);
        blueFireCollider.SetActive(false);

        //randomly activate again (after bluefire despawn) between 10-20 seconds
        Invoke("ActivateBlueFire", Random.Range(10f,20f));
    }
}
