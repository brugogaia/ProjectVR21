using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintGutenberg : MonoBehaviour
{
    // Start is called before the first frame update

    private bool enter;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            Debug.Log("OBJ");
        }
        
    }

    private void OnTriggerEnter(Collider obj)
    {

        if (obj.gameObject.tag == "Take")
        {
            enter = true;
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.tag == "Take")
        {
            enter = false;
        }
    }
}
