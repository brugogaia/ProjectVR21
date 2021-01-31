using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private float _raycastDistance;

    private CharacterController _fpsController;
    public Image _focus;
    private bool Grabbing = false;
    private GameObject GrabbedObj;
    private Transform OriginalParent;
    private Color OriginalColor;

    void Start()
    {
        OriginalColor = _focus.color;
        _fpsController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 rayOrigin = _fpsCameraT.position + _fpsCameraT.forward * _fpsController.radius;
        Ray ray = new Ray(rayOrigin, _fpsCameraT.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _raycastDistance))
        {
            if (Input.GetMouseButtonDown(1) && Grabbing == false)
                Grab(hit.transform.gameObject);
            else if (Input.GetMouseButtonDown(0) && Grabbing == true)
                Drop();
            _focus.color = new Color(1, 0, 0, 0.5f);
        }
        else
            _focus.color = OriginalColor;
        Debug.DrawRay(rayOrigin, _fpsCameraT.forward * _raycastDistance, Color.blue);

    }

    private void Grab(GameObject grabable) {
        OriginalParent = grabable.transform.parent;
        grabable.transform.SetParent(_fpsCameraT);
        grabable.GetComponent<Rigidbody>().isKinematic = true;
        Grabbing = true;
        GrabbedObj = grabable;
    }

    private void Drop() {
        GrabbedObj.transform.parent = OriginalParent;
        GrabbedObj.GetComponent<Rigidbody>().isKinematic = false;
        Grabbing = false;
    }
}
