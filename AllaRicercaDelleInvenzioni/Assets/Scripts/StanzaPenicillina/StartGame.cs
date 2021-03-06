﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject _cure;
    [SerializeField] GameObject _soldato;
    [SerializeField] SimpleGrabbable _grabbed;
    [SerializeField] GameObject _text;
    private bool _enter;
    private bool _isGrabbed;
    public Soldato scriptSoldato;
    
    // Start is called before the first frame update
    void Start()
    {
        _cure = GameObject.FindGameObjectWithTag("Penicillina");
        _grabbed = _cure.GetComponent<SimpleGrabbable>();
        _text.SetActive(false);
        _enter = false;
        _isGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        _isGrabbed = _grabbed._isGrabbed;

        if (_enter && _isGrabbed)
        {
            //Debug.Log("Enter game trigger");
            _text.SetActive(true);
            _soldato.GetComponent<SceneChanger>().enabled = true;

            if (Input.GetMouseButtonDown(0))
            {
                _text.SetActive(false);
                UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController._activeMovement = false;
            }
        } 
        else
        {
            //Debug.Log("Exit game trigger");
            _text.SetActive(false);
            _soldato.GetComponent<SceneChanger>().enabled = false;
        }

        if (_enter)
        {
            scriptSoldato.Talking();
            scriptSoldato.intrigger = true;
        }
        else
        {
            scriptSoldato.intrigger = false;
        }

    }

    private void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {
            _enter = true;
            
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            _enter = false;
            
        }
    }
}
