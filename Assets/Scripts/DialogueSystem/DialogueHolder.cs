using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueHolder : GameManager
{

    private void Awake()
    {
        StartCoroutine(dialogueSequence());
    }

    private IEnumerator dialogueSequence()
    {
        for(int i = 1; i < transform.childCount; i++)
        {
            Deactive();
            transform.GetChild(i).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);          
        }
        //gameObject.SetActive(false);
        StartCoroutine(base.loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private void Deactive()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}


