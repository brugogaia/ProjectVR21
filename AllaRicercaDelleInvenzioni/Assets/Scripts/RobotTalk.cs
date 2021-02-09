using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotTalk : MonoBehaviour {

    public Text textDisplay;
    public Image e;
    public string[] sentences;
    public string[] indovinelli;
    private int index;
    

    void Start()
    {
        e.enabled = false;
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            e.enabled = true;
            //if ()

        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
} 