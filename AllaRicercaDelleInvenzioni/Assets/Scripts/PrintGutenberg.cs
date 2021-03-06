﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintGutenberg : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] appear_obj;
    private int count;
    private Animator anim;
    DisappearOnDrop scriptcarta;
    public bool libro_move;
    public bool finecaratteri;
    private bool entrato;
    public GameObject text;
    public bool fine_anim_stampa;
    AppearTextCartaStampa fogliocanva;
    [SerializeField] GameObject fogliocarta;


    void Start()
    {
        anim = GetComponent<Animator>();
        
        appear_obj = GameObject.FindGameObjectsWithTag("AppearDrop");
        foreach (GameObject i in appear_obj)
        {
            i.SetActive(false);
        }

        scriptcarta = GameObject.Find("carta_take").GetComponent<DisappearOnDrop>();
        fogliocanva = GameObject.Find("carta_take").GetComponent<AppearTextCartaStampa>();
        scriptcarta.enabled = false;
        finecaratteri = false;
        fogliocanva.go = false;
        text.SetActive(false);
        fogliocarta.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        count = 0;
        foreach (GameObject i in appear_obj)
        {
            if (i.activeSelf)
            {
                count++;
                if(count == (appear_obj.Length - 1))
                {
                    fogliocanva.go = true;
                    scriptcarta.enabled = true;
                    finecaratteri = true;
                }
            }
            
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            foreach (GameObject i in appear_obj)
            {
                i.SetActive(true);
            }
        }

        if (fogliocarta.activeSelf)
        {
            fogliocanva.go = false;
            if (entrato && !fine_anim_stampa)
            {
                text.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetBool("close", true);
                    libro_move = true;
                }
            }
            else
            {
                text.SetActive(false);
            }   
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
