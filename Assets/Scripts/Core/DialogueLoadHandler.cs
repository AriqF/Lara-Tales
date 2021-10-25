using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueLoadHandler : GameManager
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(base.loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

 
}
