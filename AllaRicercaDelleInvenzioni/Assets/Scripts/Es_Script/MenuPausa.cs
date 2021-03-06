﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    // Start is called before the first frame update
    public bool pausa = false;
    [SerializeField] string NomeScena;
    public string checkDopo;
    private Canvas MenuMorte;
    public Canvas Zaino1;
    public Canvas Zaino2;
    private Canvas Orologio;
    public bool orol;

    private Transform healthbar;

    public Image white;
    public Animator anim;
    private Animator anim1;
    private Animator anim2;
    //public Animator anim3;
    void Start()
    {
        MenuMorte = GameObject.FindGameObjectWithTag("MenuMorte").GetComponentInParent<Canvas>();
        MenuMorte.enabled = false;
        //anim1 = GameObject.FindGameObjectWithTag("red").GetComponent<Animator>();
        //anim2 = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Animator>();
        healthbar = GameObject.FindGameObjectWithTag("HealthBar").transform;
        this.GetComponentInParent<Canvas>().enabled = false;
        if (orol) Orologio = GameObject.FindGameObjectWithTag("Orologio").GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!orol)
        {
            if (this.GetComponentInParent<Canvas>().enabled || MenuMorte.enabled || Zaino1.enabled || Zaino2.enabled)
            {
                Time.timeScale = 0;
                pausa = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                pausa = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else
        {
            if (this.GetComponentInParent<Canvas>().enabled || MenuMorte.enabled || Zaino1.enabled || Zaino2.enabled || Orologio.enabled)
            {
                pausa = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                pausa = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            NomeScena = checkDopo;
            LoadScena();
        }

        if (!pausa && !MenuMorte.enabled && Input.GetKeyDown("escape"))
        {
            this.GetComponentInParent<Canvas>().enabled = true;

        }
        /*if (pausa) {
            if (Input.GetKeyDown(KeyCode.R))
            {
                pausa = false;
                this.GetComponent<Image>().enabled = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (Input.GetKeyDown(KeyCode.T)){
                SceneManager.LoadScene(NomeScena, LoadSceneMode.Single);
            }


        }*/
    }

    public string GetNomeScena()
    {
        return NomeScena;
    }

    public void setNomeScena(string scena)
    {
        NomeScena = scena;
    }

    public void setPausa(bool boolean)
    {
        pausa = boolean;
    }

    public void LoadScena()
    {
        SceneManager.LoadScene(NomeScena, LoadSceneMode.Single);
        //healthbar.GetComponent<HealthBar>().SetCurrentHealth(1);
        //healthbar.GetComponent<HealthBar>().setIsDead(false);
    }

    public void OpenMenu()
    {
        this.GetComponentInParent<Canvas>().enabled = false;
        MenuMorte.enabled = false;
        StartCoroutine(Fading());

    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        //if(anim1!=null) anim1.SetBool("Fade", true);
        //if(anim2!=null) anim2.SetBool("Fade", true);
        //anim3.SetBool("Fade", true);
        yield return new WaitUntil(() => white.color.a == 1);
        SceneManager.LoadScene("MenuPrincipale", LoadSceneMode.Single);


    }
}


