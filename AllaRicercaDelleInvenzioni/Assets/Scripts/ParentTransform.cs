using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentTransform : MonoBehaviour
{
    private GameObject _parentGameObject;

    // Start is called before the first frame update
    void Start()
    {
        _parentGameObject = GameObject.FindGameObjectWithTag("Parent");
        Debug.Log("script detected");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _parentGameObject)
        {
            this.transform.parent = _parentGameObject.transform;
            Debug.Log("collision detected");
        }
    }

    private void onCollisionExit(Collision collision)
    {
        this.transform.parent = null;
    }
}
