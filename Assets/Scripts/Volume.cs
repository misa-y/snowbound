using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Image buttonImage;
    public Sprite volumeOnSprite;
    public Sprite volumeOffSprite;

    private bool muted = false;

    public void ToggleVolume()
    {
        muted = !muted;
        
        if (muted)
        {
            buttonImage.sprite = volumeOffSprite;
            AudioListener.volume = 0f;
        }
        else
        {
            buttonImage.sprite = volumeOnSprite;
            AudioListener.volume = 1f;
        }
    }
}
