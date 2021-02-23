using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintGutenberg : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] appear_obj;
    private bool appearAll;
    private int count;
    private Animator anim;
    DisappearOnDrop scriptcarta;
    public bool libro_move;
    private bool entrato;
    public GameObject text;
    public bool fine_anim_stampa;
    AppearTextCartaStampa fogliocanva;


    void Start()
    {
        appearAll = false;
        anim = GetComponent<Animator>();
        
        appear_obj = GameObject.FindGameObjectsWithTag("AppearDrop");
        foreach (GameObject i in appear_obj)
        {
            i.SetActive(false);
        }

        scriptcarta = GameObject.Find("carta_take").GetComponent<DisappearOnDrop>();
        fogliocanva = GameObject.Find("carta_take").GetComponent<AppearTextCartaStampa>();
        scriptcarta.enabled = false;
        fogliocanva.go = false;
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        count = 0;
        foreach (GameObject i in appear_obj)
        {
            count++;
            if (i.activeSelf)
            {
                appearAll = true;
                Debug.Log("VERO");
                if(count == (appear_obj.Length - 1))
                {
                    fogliocanva.go = true;
                    scriptcarta.enabled = true;
                }
            }
            else
            {
                appearAll = false;
                Debug.Log("FALSO");
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            foreach (GameObject i in appear_obj)
            {
                i.SetActive(true);
            }
            appearAll = true;
        }

        if (appearAll)
        {
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
