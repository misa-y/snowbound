using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // public AudioSource backgroundMusic;
    
    // void Start()
    // {
    //     backgroundMusic.Play();
    // }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}

