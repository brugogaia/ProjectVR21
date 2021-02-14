using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject canvastart;
    public GameObject canvainfo;

    void Start()
    {
        canvainfo.SetActive(false);
        canvastart.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
