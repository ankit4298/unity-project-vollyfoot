using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    // for managing multiple scene audio manager
    public static AudioManager instance;

    public AudioMixerGroup master;

    public Sounds[] sounds;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = master;

        }
    }

    void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void SetLevel(float sliderVol)
    {
        //master.audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderVol) - 60);

        Debug.Log(Mathf.Log10(sliderVol));
        master.audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderVol)*20);


    }

}
