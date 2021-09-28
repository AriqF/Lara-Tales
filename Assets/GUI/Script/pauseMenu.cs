using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuObject;

    private bool isPaused;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenuObject.SetActive(true);
        Time.timeScale = 0f;        
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
