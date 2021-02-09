using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comodino : MonoBehaviour
{
    private bool _enter = false;
    [SerializeField] GameObject _canvaTextOpen;
    [SerializeField] GameObject _canvaTextClose;

    [SerializeField] GameObject _nightstand;
    [SerializeField] Animator _animator;
    private bool _open;

    // Start is called before the first frame update
    void Start()
    {
        _canvaTextOpen.SetActive(false);
        _canvaTextClose.SetActive(false);
        _nightstand = GameObject.FindGameObjectWithTag("Comodino");
        _animator = _nightstand.GetComponent<Animator>();
        _open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_enter && !_open)
        {
            //Debug.Log("enter the trigger close nightstand");
            _canvaTextOpen.SetActive(true);
            _canvaTextClose.SetActive(false);
        }

        if (_enter && _open)
        {
            //Debug.Log("enter the trigger open nightstand");
            _canvaTextClose.SetActive(true);
            _canvaTextOpen.SetActive(false);
        }

        if (!_enter)
        {
            //Debug.Log("exit the trigger nightstand");
            _canvaTextOpen.SetActive(false);
            _canvaTextClose.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!_open)
            {
                Open();
            } else if (_open)
            {
                Close();
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

    public void Open()
    {
        if (_animator == null) return;
        _open = true;
        _animator.SetBool("open", true);
        Debug.Log("The nightstand is open");
    }

    public void Close()
    {
        if (_animator == null) return;
        _open = false;
        _animator.SetBool("open", false);
        Debug.Log("The nightstand is close");
    }
}
