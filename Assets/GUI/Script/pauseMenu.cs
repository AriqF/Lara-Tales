using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : GameManager
{
    [Header ("Panel")]
    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] GameObject restartPanel;
    [SerializeField] GameObject warningPanel;
    [SerializeField] GameObject playerDiePanel;

    [Header("Others")]
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject player;

    private int loadedScene;
    public bool isPaused { get; private set; }

    private void Awake()
    {
        loadedScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
        if(player.GetComponent<health>().currentHealth == 0)
        {
            showPlayerDiePanel();
        }
        //if (isPaused)
        //{
        //    gameManager.GetComponent<AudioSource>().Pause();
        //}
        //else
        //{
        //    gameManager.GetComponent<AudioSource>().Play();
        //}
    }

    public void Pause()
    {
        pauseMenuObject.SetActive(true);
        Time.timeScale = 0f;
        gameManager.GetComponent<AudioSource>().Pause();
    }

    public void showRestartPanel()
    {
        restartPanel.SetActive(true);
    }

    public void hideRestartPanel()
    {
        restartPanel.SetActive(false);
    }

    public void showPlayerDiePanel()
    {
        Time.timeScale = 0f;
        playerDiePanel.SetActive(true);
    }

    public void showMainMenuWarning()
    {
        warningPanel.SetActive(true);
    }

    public void hideMainMenuWarning()
    {
        warningPanel.SetActive(false);
    }

    public void Restart() 
    {
        if (player.GetComponent<health>().currentHealth == 0)
            player.GetComponent<health>().relife();

        StartCoroutine(base.loadLevel(loadedScene));     
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Resume()
    {
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
        gameManager.GetComponent<AudioSource>().Play();
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        StartCoroutine(base.loadLevel(sceneID));
    }
}
