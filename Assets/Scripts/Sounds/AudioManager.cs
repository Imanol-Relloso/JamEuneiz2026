using UnityEngine;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip[] musicSounds, sealSounds, boxSounds, doorSound;
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
        sfxSource.PlayOneShot(boxSounds[0]);
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
    
}
