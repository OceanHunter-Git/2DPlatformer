using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        Debug.Log("awake");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("awakeyes");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("awakeno");
        }
    }



    public AudioSource mainMenuMusic, levelVictoryMusic, bossBattleMusic;

    public AudioSource[] levelTracks;

    public AudioSource[] allSFX;

    public void StopPlayMusic()
    {
        mainMenuMusic.Stop();
        levelVictoryMusic.Stop();
        bossBattleMusic.Stop();

        foreach (AudioSource levelmusic in levelTracks)
        {
            levelmusic.Stop();
        }
    }

    public void PlayMenuMusic()
    {
        StopPlayMusic();
        mainMenuMusic.Play();
    }

    public void PlayBossMusic()
    {
        StopPlayMusic();
        bossBattleMusic.Play();
    }
    public void PlayVictoryMusic()
    {
        StopPlayMusic();
        levelVictoryMusic.Play();
    }

    public void PlayLevelMusic(int trackToPlay)
    {
        StopPlayMusic();
        levelTracks[trackToPlay].Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        allSFX[sfxToPlay].Stop();
        allSFX[sfxToPlay].Play();
    }

    public void PlaySFXPitch(int sfxToPlay)
    {
        allSFX[sfxToPlay].Stop();
        allSFX[sfxToPlay].pitch = Random.Range(0.75f, 1.25f);
        allSFX[sfxToPlay].Play();
    }
}
