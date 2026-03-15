using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip[] musicSounds, sealSounds, boxSounds, doorSound, Pupu, libreta;
    public AudioSource musicSource, sfxSource;

    public AudioClip MenuTheme, MainTheme;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        float volume = PlayerPrefs.GetFloat("volume", 1f);
        musicSource.volume = volume;
    }
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip)
        {
            return;
        }
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
    public float GetMusicVolume()
    {
        return musicSource.volume;
    }
    public float GetSFXVolume()
    {
        return sfxSource.volume;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu" || scene.name == "Credits" || scene.name == "Options")
        {
            PlayMusic(MenuTheme);
        }
        else if (scene.name == "SampleScene")
        {
            PlayMusic(MainTheme);
        }
    }


    public void PlayMeow(AudioClip clip)
    {
        if (clip == null) return;

        sfxSource.clip = clip;
        sfxSource.loop = true;
        sfxSource.Play();
    }

    public void StopMeow()
    {
        sfxSource.loop = false;

        if (sfxSource.isPlaying)
            sfxSource.Stop();
    }

    public void PlayBox()
    {
        sfxSource.PlayOneShot(boxSounds[Random.Range(0,boxSounds.Length)]);
    }

    public void PlayDoor()
    {
        sfxSource.PlayOneShot(doorSound[0]);
    }
    public void PlayRedSeal()
    {
        sfxSource.PlayOneShot(sealSounds[0]);
    }
    public void PlayGreenSeal()
    {
        sfxSource.PlayOneShot(sealSounds[1]);
    }
    public void PlayPupu()
    {
        sfxSource.PlayOneShot(Pupu[Random.Range(0, Pupu.Length)]);
    }
    public void PlayLibreta()
    {
        sfxSource.PlayOneShot(libreta[Random.Range(0, libreta.Length)]);
    }

}
