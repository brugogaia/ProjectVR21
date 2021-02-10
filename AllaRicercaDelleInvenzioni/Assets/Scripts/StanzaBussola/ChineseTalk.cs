using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChineseTalk : MonoBehaviour
{
    [SerializeField] GameObject _canvaTalk;
    [SerializeField] GameObject _person;
    [SerializeField] Animator _animator;
    private bool _enter = false;
    private bool _isTalking;

    // Start is called before the first frame update
    void Start()
    {
        _canvaTalk.SetActive(false);
        _person = GameObject.FindGameObjectWithTag("Persona");
        _animator = _person.GetComponent<Animator>();
        _isTalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_enter && !_isTalking)
        {
            _canvaTalk.SetActive(true);
        }
        else if (!_enter || _isTalking)
        {
            _canvaTalk.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Talk();
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
        _isTalking = true;
        _animator.SetBool("talking", true);
        Debug.Log("The person is talking");
    }
}
