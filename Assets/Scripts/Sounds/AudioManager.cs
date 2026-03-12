using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip[] musicSounds, sealSounds, boxSounds, doorSound;
    public AudioSource musicSource, sfxSource;

    private AudioClip actualSound;

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
        PlayMusic("");
    }
    public void PlayMusic(string name)
    {
        AudioClip s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            // musicSource.clip = s.clip;
            musicSource.Play();
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
