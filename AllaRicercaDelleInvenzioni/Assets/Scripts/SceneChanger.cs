﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChanger: MonoBehaviour
{
    [SerializeField] private string _target;
    [SerializeField] private bool _onInteraction;
    [SerializeField] private bool _onButton;
    [SerializeField] private bool _isStartMenu;
    [SerializeField] private Button _startButton;
    private Button _btn;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        if (_isStartMenu)
            PlayerPrefs.SetInt("Progress", 0);
        if (_onButton)
        {
            _btn = _startButton.GetComponent<Button>();
            _btn.onClick.AddListener(TransferToScene);
        }

    }

    private void OnCollisionEnter(Collision player)
    {
        if (player.collider.tag == "Player")
            TransferToScene();
    }
    

    // Update is called once per frame
    void Update()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_onInteraction && Input.GetMouseButtonDown(0) && _player.GetComponent<RayCast>()._raycasted.Equals(gameObject))
            TransferToScene();

    }

    private void TransferToScene()
    {
        SceneManager.LoadScene(_target, LoadSceneMode.Single);
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
    }
}

