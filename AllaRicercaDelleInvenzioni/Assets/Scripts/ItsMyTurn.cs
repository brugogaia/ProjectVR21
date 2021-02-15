using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItsMyTurn : MonoBehaviour
{
    [SerializeField] private int turn;
    
    // Update is called once per frame
    void Update()
    {
        if (turn == PlayerPrefs.GetInt("Progress"))
        {
            gameObject.GetComponent<DisappearOnDrop>().enabled = true;
            gameObject.GetComponent<Lumina>().enabled = true;
            if (gameObject.GetComponent<StartAudio>() != null)
            {
                gameObject.GetComponent<StartAudio>().enabled = true;
                gameObject.GetComponent<AudioSource>().enabled = true;
            }
        }

    }

    public void CompDisable()
    {
        gameObject.GetComponent<DisappearOnDrop>().enabled = false;
        gameObject.GetComponent<Lumina>().enabled = false;
        if (gameObject.GetComponent<StartAudio>() != null)
        {
            gameObject.GetComponent<StartAudio>().enabled = false;
            gameObject.GetComponent<AudioSource>().enabled = false;
        }
    }

}
