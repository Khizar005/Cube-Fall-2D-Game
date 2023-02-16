using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    private bool isMuted = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1;
        UpdateButton();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        UpdateButton();

        // Save the state of the mute button to PlayerPrefs
        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void UpdateButton()
    {
        if (isMuted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
