using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parentable : MonoBehaviour
{
    private GameObject _parentGameObject;

    // Start is called before the first frame update
    void Start()
    {
        _parentGameObject = GameObject.FindGameObjectWithTag("Parent");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _parentGameObject)
        {
            Debug.Log("collision detected");
            this.transform.parent = _parentGameObject.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == _parentGameObject)
        {
            Debug.Log("collision exit detected");
            this.transform.parent = null;
        }
    }
}
