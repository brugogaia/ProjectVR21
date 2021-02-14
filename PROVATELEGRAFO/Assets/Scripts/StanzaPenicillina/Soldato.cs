﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soldato : MonoBehaviour
{
    public GameObject _exit;
    private Animator _animator;
    private GameObject _before;
    private GameObject _after;
    private bool _cured;

    public Text textDisplay;
    public GameObject talk_box;
    public string[] sentences;
    private int index_s;
    private bool talking;
    public bool intrigger;
    

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _before = GameObject.FindGameObjectWithTag("Before");
        _after = GameObject.FindGameObjectWithTag("After");
        _cured = false;
        talking = false;
        intrigger = false;
        talk_box.SetActive(false);
        textDisplay.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Cura") == 1)
            _cured = true;
        // MANCA DA SETTARE _CURED TRUE QUANDO FINISCE IL GIOCHINO
        if (_cured)
        {
            _before.SetActive(false);
            _after.SetActive(true);
            
            if (_animator == null) return;
            _animator.SetBool("cured", true);

            Talking();
            _exit.SetActive(true);

        }
        else
        {
            _before.SetActive(true);
            _after.SetActive(false);
            if (_animator == null) return;
            _animator.SetBool("cured", false);
        }
    }

    public void Talking()
    {
        if (_cured && intrigger)
        {
            talk_box.SetActive(true);
            textDisplay.enabled = true;

            if (!talking)
            {
                StartCoroutine(Type());
                talking = true;
            }
        }
        if (!intrigger)
        {
            textDisplay.text = "";
            talk_box.SetActive(false);
            textDisplay.enabled = false;
            talking = false;
        }
        
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index_s].ToCharArray())
        {
            if(intrigger)
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}