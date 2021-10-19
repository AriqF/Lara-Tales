using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueBaseClass : MonoBehaviour
{
    public bool finished { get; private set; }
    public GameObject continueText;

    protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, AudioClip sound, float delayBetweenLines)
    {
        textHolder.color = textColor;
        textHolder.font = textFont;
        continueText.SetActive(false);

        for(int i = 0; i < input.Length; i++)
        {
            textHolder.text += input[i];
            SoundManager.instance.PlaySound(sound);
            yield return new WaitForSeconds(delay);
        }

        //yield return new WaitForSeconds(delayBetweenLines);
        continueText.SetActive(true);
        yield return new WaitUntil(() => Input.GetMouseButton(0));
        finished = true;
    }
}