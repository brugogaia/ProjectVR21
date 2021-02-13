using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItsMyTurn : MonoBehaviour
{
    [SerializeField] private int turn;
    // Start is called before the first frame update
    void Start()
    {
        if (turn == PlayerPrefs.GetInt("Progress"))
        {
            gameObject.GetComponent<DisappearOnDrop>().enabled = true; 
            gameObject.GetComponent<Lumina>().enabled = true;
            if (gameObject.GetComponent<Volumina>() != null)
                gameObject.GetComponent<Volumina>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
