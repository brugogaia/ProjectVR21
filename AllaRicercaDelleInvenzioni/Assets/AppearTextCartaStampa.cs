using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearTextCartaStampa : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _text;
    private RayCast _ray;
    public bool go;

    // Start is called before the first frame update
    void Start()
    {
        _text.SetActive(false);
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        _ray = _player.GetComponent<RayCast>();

        if (go)
        {
            if (_ray._raycasted != null)
            {
                if ((_ray._raycasted.name == this.name))
                {
                    _text.SetActive(true);
                }
                else
                {
                    _text.SetActive(false);
                }
            }
            else
            {
                _text.SetActive(false);

            }
        }
        else
        {
            _text.SetActive(false);
        }
    }
}
