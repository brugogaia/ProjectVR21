using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizAndRiddles : MonoBehaviour
{
    [SerializeField] private GameObject[] quiz;
    private int index;
    public GameObject quiz_empty;
    public string[] sentences;
    private bool start;
    public Text textDisplay;
    public GameObject talk_box;
    public GameObject quiz_image;
    private AudioSource source;
    private Animator anim;
    private bool stopmenu;
    public bool entrato;
    private bool start_quiz;
    public bool right_answer;
    public static bool endTalkTel;
    public GameObject endButton;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        foreach (GameObject q in quiz) q.SetActive(false);
        quiz_empty.SetActive(true);
        
        
        index= PlayerPrefs.GetInt("Progress");
        
        
        start = true;
        //e.enabled = false;
        talk_box.SetActive(false);
        textDisplay.enabled = false;
        entrato = false;
        right_answer = false;
        start_quiz = true;
        endTalkTel = false;
        endButton.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 0)
        {
            OpenMenu();
            StartTalking(index);
            
            
        }else if (index <= 4)
        {
            if (start_quiz)
            {
                quiz[index - 1].SetActive(true);
                EasyFPC.stop = true;
            }
            
            
            if (right_answer)
            {
                OpenMenu();
                StartTalking(index);
            }
        }
       
        
    }

    private void Anim(string input)
    {
        if (anim == null) return;

        if (input == "start")
        {
            anim.SetBool("sleep", true);
        }
        else if (input == "talk")
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

    public void Answer(bool right)
    {
        if (right)
        {
            right_answer = true;
            Debug.Log("RIGHT");
            start_quiz = false;
            quiz[index - 1].SetActive(false);
            EasyFPC.stop = false;
            

        }
        else
        {
            right_answer = false;
            Debug.Log("WRONG");
        }
    }

    IEnumerator Type(int i)
    {
        Anim("talk");
        foreach (char letter in sentences[i].ToCharArray())
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
            //e.enabled = false;

            Anim("stop");
        }
    }

    private void StartTalking(int t)
    {
        if (!stopmenu)
        {
            if (entrato)
            {
                if (start)
                {
                    Anim("talk");
                    StartCoroutine(Type(t));
                    start = false;
                }

                if (textDisplay.text == sentences[t])
                {
                    Anim("stop");
                    if (t == 4)
                    {
                        endButton.SetActive(true);
                    }else if (t == 2)
                    {
                        endTalkTel = true;
                    }
                }
            }
        }
        else
        {
            talk_box.SetActive(false);
            textDisplay.text = "";
            //e.enabled = false;
            textDisplay.enabled = false;
            Anim("stop");
        }

    }
}
