using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueLine : DialogueBaseClass
{
    private Text _textHolder;

    [Header("Text Option")]
    [SerializeField] private string _input;
    [SerializeField] private Color _textColor;
    [SerializeField] private Font _textFont;

    [Header("Time Parameter")]
    [SerializeField] private float delay;
    [SerializeField] private float delayBetweenLines;

[Header("Sound")]
    [SerializeField] private AudioClip sound;

    [Header("Character Images")]
    [SerializeField] private Sprite characterSprite;
    [SerializeField] private Image imageHolder;

    private void Awake()
    {
        _textHolder = GetComponent<Text>();
        _textHolder.text = "";
            
        imageHolder.sprite = characterSprite;
        imageHolder.preserveAspect = true;
    }

    private void Start()
    {
        StartCoroutine(WriteText(_input, _textHolder, _textColor, _textFont, delay, sound, delayBetweenLines));
    }

}


