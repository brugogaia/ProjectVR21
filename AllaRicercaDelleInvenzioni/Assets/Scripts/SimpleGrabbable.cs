using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGrabbable : Grabbable
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    public bool _isGrabbed;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        _isGrabbed = false;
    }

    public override void Grab(GameObject grabber)
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        _isGrabbed = true;
    }

    public override void Drop()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
        _isGrabbed = false;
    }
}
