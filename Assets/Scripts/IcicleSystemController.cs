using UnityEngine;

public class IcicleSystemController : MonoBehaviour
{
    // warning spots objects + icicle 
    public GameObject[] warningSpots;
    public GameObject iciclePrefab;

    // number of warnings to activate
    private int numberOfWarnings = 3;

    // time of icicle activation
    private float activeTime = 10f;

    // randomly selects warning spots to activate
    void ActivateWarnings()
    {
         //1-3 warnings will be activated (bc it might pick the same warning spot more than once)
        for (int i=0; i<numberOfWarnings; i++)
        {
            //randomly selects a warning spot to activate
            int randomIndex = Random.Range(0, warningSpots.Length);
            warningSpots[randomIndex].SetActive(true);
        }

        Invoke("SpawnIcicle", 2f); // delay the spawn of the icicles by 2 seconds     
    }

    // spawns icicles above the warning spots that were activated
    void SpawnIcicle()
    {
        for (int i=0; i<warningSpots.Length; i++)
        {
            if (warningSpots[i].activeSelf) //only spawn icicle above the warning spots that were activated
            {
                GameObject newIcicle = Instantiate(iciclePrefab, warningSpots[i].transform.position, warningSpots[i].transform.rotation, transform); //spawns icicle 5 units above the warning spot and makes it a child of the warning spot 
                warningSpots[i].SetActive(false); //deactivates the warning spot after spawning the icicle

                // destroy after 10 seconds
                Destroy(newIcicle, activeTime);
            }
        }

        //randomly activate again (after icicles despawn) between 5-30 seconds
        Invoke("ActivateWarnings", activeTime + Random.Range(5f,30f)); 
    }

    void Start()
    {
        Invoke("ActivateWarnings", Random.Range(1f, 5f)); //delay first activation of icicle obstacle by 5-10 seconds
    }
}
