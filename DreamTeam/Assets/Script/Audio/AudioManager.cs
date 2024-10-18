using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField, HideInInspector] AudioSource musicSource;
    [SerializeField, HideInInspector] AudioSource SFXSource;
    //public AudioStruct[] AudioStruct;
    public Sounds[] BGSounds;
    public Sounds[] SFX;
    public static AudioManager Instance { get; private set; }




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        PlayBackground();
    }

    private void Start()
    {

        //musicSource.clip = BGSounds[0].audioClip;
        //musicSource.Play();

    }

    private void Update()
    {
      //if (!musicSource.isPlaying)
      //{
      //    PlayBackground();
      //}


    }

    public void PlaySFXList(AudioClip[] clip)
    {
        SFXSource.PlayOneShot(clip[UnityEngine.Random.Range(0, clip.Length)]);
    }


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlaySFX(string name)
    {
        Sounds s = Array.Find(SFX, sound => sound.name == name);

        SFXSource.volume = s.volume;
        SFXSource.pitch = s.pitch;
        SFXSource.loop = s.loop;
        SFXSource.PlayOneShot(s.audioClip, SFXSource.volume);
    }

    public void PlayBackground()
    {
        Sounds s = BGSounds[UnityEngine.Random.Range(0, BGSounds.Length)];
        //Sounds s = Array.Find(BGSounds, sound => sound.name == name);

        musicSource.clip = s.audioClip;
        musicSource.volume = s.volume;
        musicSource.pitch = s.pitch;
        musicSource.loop = s.loop;
        musicSource.Play();
    }


} 