using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;

    public int startFruit = 0, startLive = 3;

    public GameObject continueButton;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMenuMusic();
        if (PlayerPrefs.HasKey("currentLevel"))
        {
            continueButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
        }
#endif
    }

    public void PlayGame()
    {
        InfoTracker.instance.currentFruit = startFruit;
        InfoTracker.instance.currentLives = startLive;

        InfoTracker.instance.SaveInfo();
        SceneManager.LoadScene(firstLevel);
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("currentLevel"));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
