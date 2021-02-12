using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assemble : MonoBehaviour
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

    private Animator _animatorCarafe;
    private Animator _animatorNeedle;
    private Animator _animatorMagnet;
    private Animator _animatorCork;

    private bool _carafeIsGrabbed = false;
    private bool _needleIsGrabbed = false;
    private bool _magnetIsGrabbed = false;
    private bool _corkIsGrabbed = false;
    private bool _carafeIsUsed = false;
    private bool _needleIsMagnetized = false;
    private bool _magnetIsUsed = false;
    private bool _needleIsSticked = false;
    private bool _corkIsUsed = false;
    private bool _compassIsReady = false;
    private bool _nextObjIsRayCasted = false;

    // Start is called before the first frame update
    void Start()
    {
        _compass.SetActive(false);
        _fluid.SetActive(false);
        _canvaSpill.SetActive(false);
        _canvaMagnetize.SetActive(false);
        _canvaStick.SetActive(false);
        _canvaInsert.SetActive(false);
        _canvaTake.SetActive(false);

        _animatorCarafe = _carafe.GetComponent<Animator>();
        _animatorNeedle = _needle.GetComponent<Animator>();
        _animatorMagnet = _magnet.GetComponent<Animator>();
        _animatorCork = _cork.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _carafeIsGrabbed = _carafe.GetComponent<SimpleGrabbable>()._isGrabbed;
        _needleIsGrabbed = _needle.GetComponent<SimpleGrabbable>()._isGrabbed;
        _magnetIsGrabbed = _magnet.GetComponent<SimpleGrabbable>()._isGrabbed;
        _corkIsGrabbed = _cork.GetComponent<SimpleGrabbable>()._isGrabbed;

        _ray = _player.GetComponent<RayCast>();

        switch (_ray._raycasted.name)
        {
            case "ciotola":
                if (_carafeIsGrabbed && !_carafeIsUsed) _nextObjIsRayCasted = true;
                break;
            case "ago":
                if ((!_needleIsMagnetized && _magnetIsGrabbed) || (_needleIsMagnetized && _corkIsGrabbed)) _nextObjIsRayCasted = true;
                break;
            case "magnete":
                if (!_magnetIsUsed && _needleIsGrabbed) _nextObjIsRayCasted = true;
                break;
            case "sughero":
                if (!_corkIsUsed && _needleIsMagnetized) _nextObjIsRayCasted = true;
                break;
            default:
                _nextObjIsRayCasted = false;
                break;
        }

        _animatorCarafe.applyRootMotion = true;

        if (_carafeIsGrabbed && _nextObjIsRayCasted && !_carafeIsUsed)
        {
            _canvaSpill.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                _animatorCarafe.applyRootMotion = false;
                if (_animatorCarafe == null) return;
                _animatorCarafe.SetBool("used_carafe", true);
                Debug.Log("Water is poured out");
                _canvaSpill.SetActive(false);
                _carafeIsUsed = true;
                _fluid.SetActive(true);
            }
            // _animatorCarafe.SetBool("used_carafe", false);
        }

        if ((_needleIsGrabbed && _nextObjIsRayCasted && !_needleIsMagnetized) || (_magnetIsGrabbed && _nextObjIsRayCasted && !_magnetIsUsed))
        {
            _canvaMagnetize.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                if (_animatorNeedle == null) return;
                if (_animatorMagnet == null) return;
                _animatorNeedle.SetBool("used_needle", true);
                _animatorMagnet.SetBool("used_magnet", true);
                Debug.Log("Needle is magnetized");
                _canvaMagnetize.SetActive(false);
                _needleIsMagnetized = true;
                _magnetIsUsed = true;
            }
            //_animatorNeedle.SetBool("used_needle", false);
            //_animatorMagnet.SetBool("used_magnet", false);
        }

        if ((_needleIsGrabbed && _nextObjIsRayCasted && _needleIsMagnetized && !_needleIsSticked) || (_corkIsGrabbed && _nextObjIsRayCasted && !_corkIsUsed))
        {
            _canvaStick.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                if (_animatorNeedle == null) return;
                if (_animatorCork == null) return;
                _animatorNeedle.SetBool("used_magnetizedNeedle", true);
                _animatorCork.SetBool("used_cork", true);
                Debug.Log("Needle is sticked");
                _canvaStick.SetActive(false);
                _needleIsSticked = true;
                _corkIsUsed = true;
            }
            //_animatorNeedle.SetBool("used_magnetizedNeedle", false);
            //_animatorMagnet.SetBool("used_cork", false);
        }

        if (((_needleIsGrabbed && _nextObjIsRayCasted && _needleIsSticked) || (_corkIsGrabbed && _nextObjIsRayCasted && _corkIsUsed)) && _carafeIsUsed)
        {
            _canvaInsert.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                if (_animatorNeedle == null) return;
                if (_animatorCork == null) return;
                _animatorNeedle.SetBool("used_stickingNeedle", true);
                _animatorCork.SetBool("used_stickedCork", true);
                Debug.Log("Compass is ready");
                _canvaInsert.SetActive(false);
                _compassIsReady = true;
            }
            //_animatorNeedle.SetBool("used_stickingNeedle", false);
            //_animatorMagnet.SetBool("used_stickedCork", false);
        }

        if (_compassIsReady)
        {
            _compass.SetActive(true);
            _notCompass.SetActive(false);
            if (_nextObjIsRayCasted)
            {
                _canvaTake.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    _canvaTake.SetActive(false);
                }
            }
            
        }
    }
}
