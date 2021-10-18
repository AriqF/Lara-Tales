using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject transitionObject;

    private float transitionTime = 1f;

    private void Awake()
    {

        //DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
    public IEnumerator loadLevel(int levelIndex)
    {
        transitionObject.GetComponent<Animator>().SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
