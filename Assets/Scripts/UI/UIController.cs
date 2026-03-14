using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Slider musicSlider, SFXSlider;

    public void Start()
    {
        float MusicVolume = AudioManager.Instance.GetMusicVolume();
        float SFXVolume = AudioManager.Instance.GetSFXVolume();
        musicSlider.value = MusicVolume;
        SFXSlider.value = SFXVolume;

        musicSlider.onValueChanged.AddListener(ChangeVolume);
    }
    void ChangeVolume(float value)
    {
        AudioManager.Instance.MusicVolume(value);
    }
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(SFXSlider.value);
    }

}

