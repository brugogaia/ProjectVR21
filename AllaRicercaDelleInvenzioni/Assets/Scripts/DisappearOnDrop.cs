using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnDrop : Grabbable
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Vector3 _origin;
    [SerializeField] GameObject _objectiveObj;
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
        if (Vector3.Distance(_objectiveObj.transform.position, transform.position) < 2.0f)
        {
            transform.position = _origin;
            gameObject.SetActive(false);
        }
    }
}
