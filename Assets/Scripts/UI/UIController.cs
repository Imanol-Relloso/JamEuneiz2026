using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Slider musicSlider, SFXSlider;

    public void Start()
    {
        musicSlider.value = musicSlider.maxValue;
        SFXSlider.value = SFXSlider.maxValue;
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

