using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCompassCanva : MonoBehaviour
{
    [SerializeField] GameObject _canvaTake;
    [SerializeField] GameObject _player;
    private RayCast _ray;
    private bool _isGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        _canvaTake.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _isGrabbed = this.GetComponent<SimpleGrabbable>()._isGrabbed;
        _ray = _player.GetComponent<RayCast>();
        if (_ray._raycasted != null)
        {
            if (_ray._raycasted.name == this.name)
            {
                _canvaTake.SetActive(true);
                if (_isGrabbed)
                { 
                    _canvaTake.SetActive(false);
                }
                else
                {
                    _canvaTake.SetActive(true);
                }
            }
            else
            {
                _canvaTake.SetActive(false);
            }
        }
    }
}
