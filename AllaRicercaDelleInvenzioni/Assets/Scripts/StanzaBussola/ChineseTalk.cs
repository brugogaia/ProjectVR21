using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChineseTalk : MonoBehaviour
{
    [SerializeField] GameObject _canvaTalk;
    [SerializeField] GameObject _person;
    [SerializeField] Animator _animator;
    private AudioSource source;
    public Text textDisplay;
    public Image e;
    public GameObject talk_box;
    public string[] sentences;
    private bool _enter = false;
    private bool start_talking;
    private int index_s;

    // Start is called before the first frame update
    void Start()
    {
        _canvaTalk.SetActive(false);
        _person = GameObject.FindGameObjectWithTag("Persona");
        source = GetComponent<AudioSource>();
        _animator = _person.GetComponent<Animator>();

        talk_box.SetActive(false);
        textDisplay.enabled = false;
        e.enabled = false;
        start_talking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_enter)
        {
            Talk();
        }
        else if (!_enter)
        {
            StopTalk();
        }

        if (!start_talking && _enter)
        {
            StartCoroutine(Type());
            start_talking = true;
        }
        
        if (textDisplay.text == sentences[index_s])
        {
            source.Stop();
            _animator.SetBool("talking", false);
            if (index_s < sentences.Length - 1)
            {
                e.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    NextSentence();
                }
            } 
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

    public void Talk()
    {
        if (_animator == null) return;
        _animator.SetBool("talking", true);
        talk_box.SetActive(true);
        textDisplay.enabled = true;
        Debug.Log("The person is talking");
    }

    public void StopTalk()
    {
        if (_animator == null) return;
        source.Stop();
        _animator.SetBool("talking", false);
        talk_box.SetActive(false);
        textDisplay.text = "";
        textDisplay.enabled = false;
        e.enabled = false;
        start_talking = false;
        Debug.Log("The person stops talking");
    }

    IEnumerator Type()
    {
        source.Play();
        _animator.SetBool("talking", true);
        foreach (char letter in sentences[index_s].ToCharArray())
        {            
            if (_enter)
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(0.05f);
            }

        }
    }

    private void NextSentence()
    {
        e.enabled = false;
        if (index_s < sentences.Length - 1)
        {
            index_s++;
            textDisplay.text = "";
            _animator.SetBool("talking", true);
            StartCoroutine(Type());
        }
        else
        {
            StopTalk();
        }
    }

}
