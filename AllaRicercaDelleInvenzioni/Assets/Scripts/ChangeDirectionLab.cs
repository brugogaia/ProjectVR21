using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirectionLab : MonoBehaviour
{
    private bool entrato = false;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        entrato = false;
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (entrato)
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {
            entrato = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            entrato = false;
        }
    }
}
