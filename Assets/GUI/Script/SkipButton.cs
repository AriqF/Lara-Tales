using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : GameManager
{
    [SerializeField] GameObject skipPanel;
    private int currScene;

    private void Awake()
    {
        currScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void showSkipPanel()
    {
        skipPanel.SetActive(true);
    }
    public void hideSkipPanel()
    {
        skipPanel.SetActive(false);
    }
    public void skipStory()
    {
        if (currScene <= 3)
            StartCoroutine(base.loadLevel(4));
        else if (currScene >= 4 && currScene <= 7)
            StartCoroutine(base.loadLevel(8));
        else if (currScene == 9)
            StartCoroutine(base.loadLevel(currScene + 1));
        else if (currScene >= 11 && currScene <= 12)
            StartCoroutine(base.loadLevel(13));
        else if (currScene >= 13 && currScene <= 16)
            StartCoroutine(base.loadLevel(17));
        else if (currScene == 17)
            StartCoroutine(base.loadLevel(18));
        else if (currScene == 18)
            StartCoroutine(base.loadLevel(0));
        else
            StartCoroutine(base.loadLevel(currScene));
    }
}
