using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    void Start()
    {
        GetMusicAndSFXButton();
    }
    public Slider _musicSlider, _sfxSlider;
    // public float volume;
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }
    public void PlayMusic()
    {
        AudioManager.Instance.playMusic();
    }
    public void ToggleSFX()
    {

        AudioManager.Instance.ToggleSFX();
    }
    public void PlaySFX()
    {
        AudioManager.Instance.playSFX();
    }
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

    public GameObject music, sfx, muteMusic, mutesfx;
    private string musicStr, sfxStr, muteMusicStr, mutesfxStr;
    public void GetMusicAndSFXButton()
    {
        musicStr=PlayerPrefs.GetString("Music");
        if (musicStr == "clicked")
        {
            music.SetActive(false);
            muteMusic.SetActive(true);
            ToggleMusic();
        }
        muteMusicStr =PlayerPrefs.GetString("MuteMusic");
         if (muteMusicStr == "clicked")
        {
            music.SetActive(true);
            muteMusic.SetActive(false);
            

        }
        sfxStr= PlayerPrefs.GetString("SFX");
        if (sfxStr=="clicked")
        {
            sfx.SetActive(false);
            mutesfx.SetActive(true);
            ToggleSFX();
        }
        mutesfxStr=PlayerPrefs.GetString("MuteSFX");
         if (mutesfxStr == "clicked")
        {
            sfx.SetActive(true);
            mutesfx.SetActive(false);
        }

    }
 


    public void MusicButton()
    {
        PlayerPrefs.SetString("Music", "clicked");
        PlayerPrefs.SetString("MuteMusic", "null");
    }
    public void MuteMusicButton()
    {
        PlayerPrefs.SetString("Music", "null");
        PlayerPrefs.SetString("MuteMusic", "clicked");


    }

    public void SFXButton()
    {
        PlayerPrefs.SetString("SFX", "clicked");
        PlayerPrefs.SetString("MuteSFX", "null");

    }
    public void MuteSFXButton()
    {
        PlayerPrefs.SetString("SFX", "null");
        PlayerPrefs.SetString("MuteSFX", "clicked");

    }

}
