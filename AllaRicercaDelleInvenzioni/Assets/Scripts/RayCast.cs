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
    private Grabbable GrabbedObj;
    private Transform OriginalParent;
    private Grabbable _pointingGrabbable;
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
            _focus.color = new Color(1, 0, 0, 0.5f);
            _pointingGrabbable = hit.transform.GetComponent<Grabbable>();
            if (Input.GetMouseButtonDown(1) && Grabbing == false && _pointingGrabbable) {
                
                _pointingGrabbable.Grab(gameObject);
                Grab(_pointingGrabbable);
            }
             
        } else
            _focus.color = OriginalColor;
        Debug.DrawRay(rayOrigin, _fpsCameraT.forward * _raycastDistance, Color.blue);

        if (Input.GetMouseButtonDown(0) && Grabbing == true)
            Drop();
    }

    private void Grab(Grabbable grabbable) {
        GrabbedObj = grabbable;
        grabbable.transform.SetParent(_fpsCameraT);
        Grabbing = true;

    }

    private void Drop() {
        GrabbedObj.Drop();
        GrabbedObj.transform.parent = GrabbedObj.OriginalParent;
        Grabbing = false;
    }
}
