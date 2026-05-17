using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    public void ToggleShadows(bool enabled)
    {
        QualitySettings.shadows =
            enabled ? ShadowQuality.All : ShadowQuality.Disable;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}