using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGrabbable : Grabbable
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
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
    }
}
