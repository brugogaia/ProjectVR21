using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueRobotStart : MonoBehaviour
{
    public Text textDisplay;
    public Image e;
    public GameObject talk_box;[TextArea(3, 10)]
    private AudioSource source;
    private Animator anim;
    private bool stopmenu;
    public string[] sentences;
    public bool entrato;
    public bool start;
    private int index;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        e.enabled = false;
        talk_box.SetActive(false);
        textDisplay.enabled = false;
        entrato = false;
        start = true;

        Anim("start");

        index = PlayerPrefs.GetInt("Frasi");
    }

    // Update is called once per frame
    void Update()
    {
        OpenMenu();

        if (!stopmenu && index <= sentences.Length-1)
        {
            if (entrato)
            {

            }
        } else if (!stopmenu && index > sentences.Length - 1)
        {
            Anim("stop");

        }
        
    }

    private void Anim(string input)
    {
        if (anim == null) return;
        
        if (input == "start")
        {
            anim.SetBool("sleep", true);
        }
        else if(input== "talk")
        {
            anim.SetBool("wakeup", true);
            anim.SetBool("head", true);
            anim.SetBool("sleep", false);
        }
        else if (input == "stop")
        {
            anim.SetBool("sleep", false);
            anim.SetBool("head", true);
            
        }
    }
    private void OpenMenu()
    {
        if (EasyFPC.stop == true)
        {
            stopmenu = true;
        }
        else
        {
            stopmenu = false;
        }
    }

    private void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {
            if (!entrato)
            {
                start = true;
            }

            entrato = true;
            talk_box.SetActive(true);
            textDisplay.enabled = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            entrato = false;
            talk_box.SetActive(false);
            textDisplay.text = "";
            textDisplay.enabled = false;
            source.Stop();
            
            Anim("stop");
        }
    }
}
