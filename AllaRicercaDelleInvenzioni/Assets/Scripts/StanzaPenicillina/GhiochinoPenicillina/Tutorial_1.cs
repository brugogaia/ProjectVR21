using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_1 : MonoBehaviour
{

    private bool UpFlag = false;
    private bool DownFlag = false;
    public GameObject _tutorial2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            UpFlag = true;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            DownFlag = true;
        if (UpFlag && DownFlag)
        {
            gameObject.SetActive(false);
            _tutorial2.SetActive(true);
        }
    }
}
