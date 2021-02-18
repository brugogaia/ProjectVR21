using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGrabbable : Grabbable
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    [SerializeField] private bool _autoDropOnRange;
    [SerializeField] private GameObject _objectiveObj;
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

    public override bool getAutoDrop()
    {
        return _autoDropOnRange;
    }

    public override bool OnRange()
    {
        if (_objectiveObj!=null)
            return Vector3.Distance(_objectiveObj.transform.position, transform.position) < 0.6f;
        return false;
    }
}
