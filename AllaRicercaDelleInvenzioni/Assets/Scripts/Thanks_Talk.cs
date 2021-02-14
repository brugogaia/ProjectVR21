using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Thanks_Talk : MonoBehaviour
{
    public Text textDisplay;
    [TextArea(3,10)]

    public string[] thanks;
    private int index;
    public GameObject exit;
    public float typing_speed;
    // Start is called before the first frame update
    void Start()
    {
        textDisplay.enabled = true;
        exit.SetActive(false);
        index = 0;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        StartCoroutine(Type());
                
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == thanks[index])
        {
            exit.SetActive(true); 
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

    IEnumerator Type()
    {
        foreach (char letter in thanks[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typing_speed);
        }
    }
}
