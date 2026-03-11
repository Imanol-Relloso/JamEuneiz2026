using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class AudioManager: MonoBehaviour
{
    public static AudioManager Instance;
    
    public AudioClip[] musicSounds, meowSounds, sealSounds, boxSounds, doorSound;
    public AudioSource musicSource ,sfxSource;

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

    public void PlaySFX(string name) // Esto es para los otros sonidos que no son randomizados, de esto me encargoyo, que no hay proeblams cpn esto
    {
        AudioClip s = Array.Find(meowSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
        }
    }

    public void PlayMeow()
    {
        if(sfxSource.isPlaying)
        {
            sfxSource.Stop();
            return;
        }
        if(actualSound == null)
        {
            int index = Random.Range(0, meowSounds.Length);
            actualSound = meowSounds[index];
        }
        sfxSource.clip = actualSound;
        sfxSource.Play();
    }

    public void PlayBox()
    {
        sfxSource.PlayOneShot(boxSounds[0]);   
    }

    public void PlayDoor()
    {
        sfxSource.PlayOneShot(doorSound[0]);
    }
}
