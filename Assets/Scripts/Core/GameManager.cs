using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject transitionObject;

    private float transitionTime = 1f;
    //private int currScene;
    //private bool mainMenuLoaded, stage01Loaded, stage02Loaded, stage03Loaded;

    private void Awake()
    {
        //currScene = SceneManager.GetActiveScene().buildIndex;
        //if(currScene == 0)
        //{
        //    print("scene loaded is main menu!");
        //}
        //switch (currScene)
        //{
        //    case 0:
        //        print("scene loaded is main menu!");
        //        mainMenuLoaded = true;
        //        break;
        //    case 1:
        //        print("scene loaded is stage cave!");
        //        stage01Loaded = true;
        //        break;
        //    case 2:
        //        print("scene loaded is stage fire!");
        //        stage02Loaded = true;
        //        break;
        //    case 3:
        //        print("scene loaded is last stage!");
        //        stage03Loaded = true;
        //        break;
        //    default:
        //        print("scene loaded is story scene!");
        //        break;
        //}
        
        ////debuging purposes
        //if (mainMenuLoaded)
        //{
        //    print("mainMenu true");
        //}
        //if (stage01Loaded)
        //{
        //    print("stage01 true");
        //}

        //DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
