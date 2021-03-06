﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationGrabbable : Grabbable
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Vector3 _origin;
    [SerializeField] private GameObject _objectiveObj;
    [SerializeField] private GameObject _activableObj;
    //  [SerializeField] private bool _returnToOrigin;
    [SerializeField] private bool _autoDropOnRange;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        _origin = transform.position;
    }


    public override void Grab(GameObject grabber)
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
    }

    public override void Drop()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
        if (Vector3.Distance(_objectiveObj.transform.position, transform.position) < 1.2f)
        {
            transform.position = _origin;
            gameObject.SetActive(false);
            if (_activableObj != null)
            {
                _activableObj.SetActive(true);
            }
        }
    }

    public override bool getAutoDrop()
    {
        return _autoDropOnRange;
    }

    public override bool OnRange()
    {
        if (_objectiveObj != null)
            return Vector3.Distance(_objectiveObj.transform.position, transform.position) < 0.6f;
        return false;
    }

}
