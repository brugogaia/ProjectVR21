using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_2 : MonoBehaviour
{
    private bool SpaceFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SpaceFlag = true;
            if (SpaceFlag)
            {
                gameObject.SetActive(false);
                GameSystem._startFlag = true;
            }
        }
    }
}
