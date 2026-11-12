using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded; // look for scene changes
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // music starts and doesn't cut when scene change to instructions scene

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) // if there is a scene change, check if its the game scene, if it yes --> stop music
    {
        if (scene.name == "Game")
        {
            Destroy(gameObject); // stops THIS music when game is loaded
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // remove the listener when the object is destroyed
    }   
    
}
