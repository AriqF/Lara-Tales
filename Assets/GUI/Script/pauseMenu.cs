using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] GameObject restartPanel;
    [SerializeField] GameObject playerDiePanel;
    [SerializeField] GameObject player;

    private bool isPaused;
    private int loadedScene;

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
    }

    public void Pause()
    {
        pauseMenuObject.SetActive(true);
        Time.timeScale = 0f;        
    }

    public void showRestartPanel()
    {
        restartPanel.gameObject.SetActive(true);
    }

    public void hideRestartPanel()
    {
        restartPanel.gameObject.SetActive(false);
    }

    private void showPlayerDiePanel()
    {
        Time.timeScale = 0f;
        playerDiePanel.gameObject.SetActive(true);
    }

    public void Restart() 
    {
        SceneManager.LoadScene(loadedScene);
    }

    public void Resume()
    {
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
