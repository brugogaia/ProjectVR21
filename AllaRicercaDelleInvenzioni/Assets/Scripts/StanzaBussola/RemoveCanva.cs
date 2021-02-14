using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCanva : MonoBehaviour
{
    private bool _enter = false;
    [SerializeField] GameObject _canva;

    // Update is called once per frame
    void Update()
    {
        if (_enter)
        {
            _canva.SetActive(false);
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
}
