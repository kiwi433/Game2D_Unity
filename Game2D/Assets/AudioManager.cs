using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{[Header ("-------------Audio Source--------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("-------------Audio Clip--------")]
    public AudioClip Background;
    public AudioClip death;
    public AudioClip run;
    public AudioClip jump;
    public AudioClip roi;
    public AudioClip playButton;
    public AudioClip gameOver;
    public AudioClip gamewin;
    public AudioClip collect;
    public AudioClip matmau;
    public AudioClip dungTrap;
    public AudioClip no;
    public AudioClip ban;
    public AudioClip dichchuyen;

    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("sxfVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
        playBackground();
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("sxfVolume");

        SetMusicVolume();
        SetSFXVolume();
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sxfVolume", volume);
    }
    public float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat("sxfVolume", 1f); // Return 1f as default if not set

    }
    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("musicVolume", 1f); // Return 1f as default if not set
    }

    public void playBackground()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }
    public void Pause()
    {
        musicSource.clip = Background;
        musicSource.Stop();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("sxfVolume", SFXSlider.value);
        PlayerPrefs.Save();
    }
}
