using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueRobotStart : MonoBehaviour
{
    public Text textDisplay;
    public Image e;
    public GameObject talk_box;
    public GameObject quiz_image;
    private AudioSource source;
    private Animator anim;
    private bool stopmenu;
    public string[] sentences;
    public bool entrato;
    public bool start;
    private int index;
    public QuizAndRiddles quiz;


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
        quiz_image.SetActive(false);

        Anim("start");
        quiz.enabled = false;

        index = PlayerPrefs.GetInt("Frasi");
        //index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        OpenMenu();

        if (!stopmenu && index <= sentences.Length-1)
        {
            if (entrato)
            {
                if (start)
                {
                    Anim("talk");
                    StartCoroutine(Type());
                    start = false;
                }

                if (textDisplay.text == sentences[index])
                {
                    Anim("stop");
                    e.enabled = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (index <= sentences.Length - 1)
                        {

                            NextSentence();
                        }
                        else if (index == sentences.Length - 1)
                        {
                            index++;
                            PlayerPrefs.SetInt("Frasi", index);
                        }
                    }
                }
            }
        } else if (!stopmenu && index > sentences.Length - 1)
        {
            Anim("stop");
            Debug.Log("fine sentences");
            talk_box.SetActive(false);
            textDisplay.text = "";
            e.enabled = false;
            textDisplay.enabled = false;

            //finescript
            quiz.enabled = true;
            this.enabled = false;


        } else
        {
            talk_box.SetActive(false);
            textDisplay.text = "";
            e.enabled = false;
            textDisplay.enabled = false;
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
            source.Play();
            anim.SetBool("wakeup", true);
            anim.SetBool("head", true);
            anim.SetBool("sleep", false);
        }
        else if (input == "stop")
        {
            source.Stop();
            anim.SetBool("sleep", false);
            anim.SetBool("head", false);
            
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

    IEnumerator Type()
    {
        Anim("talk");
        foreach (char letter in sentences[index].ToCharArray())
        {
            if (entrato)
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(0.03f);
            }

        }
    }

    private void NextSentence()
    {
        index++;
        PlayerPrefs.SetInt("Frasi", index);
        e.enabled = false;
        if (index <= sentences.Length - 1)
        {
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            talk_box.SetActive(false);
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
            e.enabled = false;
                        
            Anim("stop");
        }
    }
}
