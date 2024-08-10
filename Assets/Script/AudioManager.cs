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
            SetInstanceAM();
            Debug.Log("awakeyes");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("awakeno");
        }
    }

    public void SetInstanceAM()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public AudioSource mainMenuMusic, levelVictoryMusic, bossBattleMusic;

    public AudioSource[] levelTracks;

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
}
