using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    [SerializeField] GameObject transitionObject;
    private float transitionTime = 1f;

    public void playGame()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));     
    }

    public void quitGame()
    {
        Application.Quit();
    }

    IEnumerator loadLevel(int levelIndex)
    {
        transitionObject.GetComponent<Animator>().SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
