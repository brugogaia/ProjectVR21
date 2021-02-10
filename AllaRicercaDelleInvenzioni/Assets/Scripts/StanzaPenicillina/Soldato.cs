using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldato : MonoBehaviour
{
    private Animator _animator;
    private GameObject _before;
    private GameObject _after;
    private bool _cured;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _before = GameObject.FindGameObjectWithTag("Before");
        _after = GameObject.FindGameObjectWithTag("After");
        _cured = false;
    }

    // Update is called once per frame
    void Update()
    { 
        // MANCA DA SETTARE _CURED TRUE QUANDO FINISCE IL GIOCHINO
        // _cured = true;
        if (_cured)
        {
            _before.SetActive(false);
            _after.SetActive(true);
            if (_animator == null) return;
            _animator.SetBool("cured", true);
        }
        else
        {
            _before.SetActive(true);
            _after.SetActive(false);
            if (_animator == null) return;
            _animator.SetBool("cured", false);
        }
    }
}
