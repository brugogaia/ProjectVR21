using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotTalk : MonoBehaviour {

    public Text textDisplay;
    public Image e;
    public GameObject talk_box;
    private AudioSource source;
    private Animator anim;
    private bool stopmenu;
    public string[] sentences;
    public string[] riddles;
    public bool entrato;
    public bool start;
    private int index_s;
    private int index_r;


    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        e.enabled = false;
        entrato = false;
        start = true;
        talk_box.SetActive(false);
        textDisplay.enabled = false;

        anim.SetBool("sleep", true);

        index_r = PlayerPrefs.GetInt("Progress");
        index_s = PlayerPrefs.GetInt("Frasi");

    }

    private void Update() {

        if (EasyFPC.stop==true)
        {
            Debug.Log("stopmenu");
            stopmenu = true;
        }else
        {
            Debug.Log("exitmenu");
            stopmenu = false;
        }

        if (!stopmenu)
        {
            if (entrato && (index_s <= sentences.Length - 1))
            {
                if (start)
                {
                    anim.SetBool("wakeup", true);
                    anim.SetBool("head", true);
                    anim.SetBool("sleep", false);
                    StartCoroutine(Type(sentences, index_s));
                    start = false;
                }

                if (textDisplay.text == sentences[index_s])
                {
                    source.Stop();
                    anim.SetBool("head", false);
                    if (index_s < sentences.Length - 1)
                    {
                        e.enabled = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            NextSentence();
                        }
                    }
                    else if (index_s == sentences.Length - 1)
                    {
                        index_s++;
                        PlayerPrefs.SetInt("Frasi", index_s);
                    }

                }
            }
            else if (entrato && (index_r <= riddles.Length - 1))
            {
                if (start)
                {
                    StartCoroutine(Type(riddles, index_r));
                    start = false;
                }

                if (textDisplay.text == riddles[index_r])
                {
                    source.Stop();
                    anim.SetBool("head", false);
                }
            }
        }
        else
        {
            talk_box.SetActive(false);
            textDisplay.text = "";
            e.enabled = false;
            textDisplay.enabled = false;
            source.Stop();
        }
    }

    IEnumerator Type(string[] phrase, int s)
    {
        source.Play();
        anim.SetBool("head", true);
        foreach (char letter in phrase[s].ToCharArray())
        {
            if (entrato)
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
            
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
            anim.SetBool("head", false);
        }
    }

    private void NextSentence()
    {
        index_s++;
        PlayerPrefs.SetInt("Frasi", index_s);
        e.enabled = false;
        if (index_s <= sentences.Length - 1)
        {
            textDisplay.text = "";
            StartCoroutine(Type(sentences, index_s));
        }
        else
        {
            textDisplay.text = "";
            talk_box.SetActive(false);
        }
    }
} 