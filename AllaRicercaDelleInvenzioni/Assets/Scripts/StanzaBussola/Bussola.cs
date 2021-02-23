using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bussola : MonoBehaviour
{
    [SerializeField] GameObject _canvaSpill;
    [SerializeField] GameObject _canvaMagnetize;
    [SerializeField] GameObject _canvaStick;
    [SerializeField] GameObject _canvaInsert;
    [SerializeField] GameObject _canvaTake;

    [SerializeField] GameObject _player;
    private RayCast _ray;

    [SerializeField] GameObject _bowl;
    [SerializeField] GameObject _carafe;
    [SerializeField] GameObject _needle;
    [SerializeField] GameObject _magnet;
    [SerializeField] GameObject _cork;
    [SerializeField] GameObject _fluid;
    [SerializeField] GameObject _compass;
    [SerializeField] GameObject _notCompass;
    [SerializeField] GameObject _preStick;
    [SerializeField] GameObject _postStick;
    [SerializeField] GameObject _newCork;
    [SerializeField] GameObject _newNeedle;
    [SerializeField] GameObject _postCork;
    [SerializeField] GameObject _postCork_audio;
    [SerializeField] GameObject _postCorkWater_audio;
    [SerializeField] GameObject _maze;

    private Vector3 _originCarafe;
    private Vector3 _originMagnet;
    private Vector3 _originNeedle;

    private bool _carafeIsGrabbed = false;
    private bool _needleIsGrabbed = false;
    private bool _magnetIsGrabbed = false;
    private bool _corkIsGrabbed = false;
    private bool _corkPostStickIsGrabbed = false;
    private bool _needleIsRayCasted = false;
    private bool _magnetIsRayCasted = false;
    private bool _corkIsRayCasted = false;
    private bool _bowlIsRayCasted = false;
    private bool _carafeIsUsed = false;
    private bool _needleIsMagnetized = false;
    private bool _magnetIsUsed = false;
    private bool _needleIsSticked = false;
    private bool _corkIsUsed = false;
    private bool _compassIsReady = false;

    // Start is called before the first frame update
    void Start()
    {
        _postStick.SetActive(false);
        _compass.SetActive(false);
        _fluid.SetActive(false);
        _canvaSpill.SetActive(false);
        _canvaMagnetize.SetActive(false);
        _canvaStick.SetActive(false);
        _canvaInsert.SetActive(false);
        _canvaTake.SetActive(false);
        _maze.SetActive(false);

        _originCarafe = _carafe.transform.position;
        _originMagnet = _magnet.transform.position;
        _originNeedle = _needle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _carafeIsGrabbed = _carafe.GetComponent<SimpleGrabbable>()._isGrabbed;
        _needleIsGrabbed = _needle.GetComponent<SimpleGrabbable>()._isGrabbed;
        _magnetIsGrabbed = _magnet.GetComponent<SimpleGrabbable>()._isGrabbed;
        _corkIsGrabbed = _cork.GetComponent<SimpleGrabbable>()._isGrabbed;
        _corkPostStickIsGrabbed = _postCork.GetComponent<SimpleGrabbable>()._isGrabbed;

        _ray = _player.GetComponent<RayCast>();
        if (_ray._raycasted != null)
        {
            switch (_ray._raycasted.name)
            {
                case "ciotola":
                    _bowlIsRayCasted = true;
                    break;
                case "ago":
                    _needleIsRayCasted = true;
                    break;
                case "magnete":
                    _magnetIsRayCasted = true;
                    break;
                case "sughero":
                    _corkIsRayCasted = true;
                    break;
                default:
                    _needleIsRayCasted = false;
                    _magnetIsRayCasted = false;
                    _corkIsRayCasted = false;
                    _bowlIsRayCasted = false;
                    break;
            }
        }
        if (_carafeIsGrabbed && _bowlIsRayCasted && !_carafeIsUsed)
        {
            _canvaSpill.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Water is poured out");
                _carafe.GetComponent<AudioSource>().Play();
                _canvaSpill.SetActive(false);
                _carafeIsUsed = true;
                _fluid.SetActive(true);

                _carafe.GetComponent<SimpleGrabbable>().Drop();
                _player.GetComponent<RayCast>().Drop();
                _carafe.GetComponent<Animation>().Play();
                //_carafe.transform.position = _originCarafe;
            }
        }
        else
        {
            _canvaSpill.SetActive(false);
        }

        if ((_needleIsGrabbed && _magnetIsRayCasted && !_needleIsMagnetized) || (_magnetIsGrabbed && _needleIsRayCasted && !_magnetIsUsed))
        {
            _canvaMagnetize.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Needle is magnetized");
                _magnet.GetComponent<AudioSource>().Play();
                _canvaMagnetize.SetActive(false);
                _needleIsMagnetized = true;
                _magnetIsUsed = true;

                _magnet.GetComponent<SimpleGrabbable>().Drop();
                //_magnet.transform.position = _originMagnet;
                _needle.GetComponent<SimpleGrabbable>().Drop();
                //_needle.transform.position = _originNeedle;
                _player.GetComponent<RayCast>().Drop();
                _magnet.GetComponent<Animation>().Play();
                _needle.GetComponent<Animation>().Play();

            }
        }
        else
        {
            _canvaMagnetize.SetActive(false);
        }

        if (((_needleIsGrabbed && _corkIsRayCasted) || (_corkIsGrabbed && _needleIsRayCasted)) && (!_corkIsUsed && _needleIsMagnetized && !_needleIsSticked))
        {
            _canvaStick.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Needle is sticked");
                _postCork_audio.GetComponent<AudioSource>().Play();
                _canvaStick.SetActive(false);

                _needle.GetComponent<SimpleGrabbable>().Drop();
                _cork.GetComponent<SimpleGrabbable>().Drop();
                _player.GetComponent<RayCast>().Drop();

                _preStick.SetActive(false);
                _postStick.SetActive(true);
                _newCork.GetComponent<Animation>().Play();
                _newNeedle.GetComponent<Animation>().Play();
                //_newNeedle.transform.parent = _newCork.transform;
                _needleIsSticked = true;
                _corkIsUsed = true;
            }
        }
        else
        {
            _canvaStick.SetActive(false);
        }

        if (_newCork.GetComponent<SimpleGrabbable>()._isGrabbed)
        {
            _newNeedle.transform.parent = _newCork.transform;
        }

        if ((_corkPostStickIsGrabbed && _bowlIsRayCasted && _carafeIsUsed))
        {
            _canvaInsert.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Compass is ready");
                _postCorkWater_audio.GetComponent<AudioSource>().Play();
                _canvaInsert.SetActive(false);
                _compassIsReady = true;

                _needle.GetComponent<SimpleGrabbable>().Drop();
                _cork.GetComponent<SimpleGrabbable>().Drop();
                _player.GetComponent<RayCast>().Drop();
            }
        }
        else
        {
            _canvaInsert.SetActive(false);
        }

        if ((_compassIsReady)|| (Input.GetKeyDown(KeyCode.I)))
        {
            _compass.SetActive(true);
            _notCompass.SetActive(false);
            _maze.SetActive(true);
        }
    }
}
