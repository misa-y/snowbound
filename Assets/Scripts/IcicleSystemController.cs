using UnityEngine;

public class IcicleSystemController : MonoBehaviour
{
    // warning spots objects + icicle 
    public GameObject[] warningSpots;
    public GameObject iciclePrefab;

    // number of warnings to activate
    private int numberOfWarnings = 3;

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

        Invoke("SpawnIcicle", 1.5f); // delay the spawn of the icicles by 1.5 seconds     
    }

    // spawns icicles above the warning spots that were activated
    void SpawnIcicle()
    {
        for (int i=0; i<warningSpots.Length; i++)
        {
            if (warningSpots[i].activeSelf) //only spawn icicle above the warning spots that were activated
            {
                Instantiate(iciclePrefab, warningSpots[i].transform.position, warningSpots[i].transform.rotation, transform); //spawns icicle 5 units above the warning spot and makes it a child of the warning spot 
                warningSpots[i].SetActive(false); //deactivates the warning spot after spawning the icicle
            }
        }
    }

    void Start()
    {
        ActivateWarnings();
    }
}
