using UnityEngine;

public class SnowballSystem : MonoBehaviour
{
    public GameObject[] snowballs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject snowball in snowballs)
        {
            snowball.SetActive(false);
        }

        Invoke("ActivateRandomSnowball", Random.Range(5f, 20f));
    }

    void ActivateRandomSnowball()
    {
        int amountActive = Random.Range(1,5); //1-4 active snowballs at a time
        int activated = 0;
        
        while (activated < amountActive)
        {
            int randomSnowball = Random.Range(0, snowballs.Length);

            if (!snowballs[randomSnowball].activeSelf)
            {
                snowballs[randomSnowball].SetActive(true);
                activated++;
            }
        }

        Invoke("DeactivateSnowball", 5f);
    }

    void DeactivateSnowball()
    {
        foreach (GameObject snowball in snowballs)
        {
            snowball.SetActive(false);
        }

        Invoke("ActivateRandomSnowball", Random.Range(10f, 25f));
    }
}