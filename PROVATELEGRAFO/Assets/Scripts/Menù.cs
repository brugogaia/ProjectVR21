using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menù : MonoBehaviour
{
    public GameObject menuPausa;
   // public Image white;
    //public Animator anim;
    private GameObject[] menu;
    private bool pausa;

    void Start()
    {
        pausa = false;
        menu = GameObject.FindGameObjectsWithTag("Menu");
        foreach (GameObject i in menu)
        {
            i.SetActive(false);
        }
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape))&&(!pausa))
        {
            menuPausa.SetActive(true);
            EasyFPC.stop = true;
            pausa = true;
        }
    }

    public void ExitMenu()
    {
        EasyFPC.stop = false;
        pausa = false;

        foreach (GameObject i in menu)
        {
            i.SetActive(false);
        }
    }

    public void OpenMenu()
    {
        foreach (GameObject i in menu)
        {
            i.SetActive(false);
        }

        SceneManager.LoadScene("Inizio", LoadSceneMode.Single);

        //StartCoroutine(Fading());
    }

    /*IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => white.color.a == 1);
        Debug.Log("FINE");
        SceneManager.LoadScene("Inizio", LoadSceneMode.Single);
    }*/

}
