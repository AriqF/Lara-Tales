using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restartText : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<health>().fallToDeath == true)
            gameObject.GetComponent<UnityEngine.UI.Text>().text = "Kamu Jatuh Kedalam Jurang Abyss!";
        else
            gameObject.GetComponent<UnityEngine.UI.Text>().text = "Waspadalah Terhadap jebakan dan musuh";
    }
}
