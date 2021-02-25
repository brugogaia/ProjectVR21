using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyFPC : MonoBehaviour
{
    [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _mouseSensitivity = 100f;
    
    private CharacterController _characterController;
    private AudioSource _footSound;
    private float _position;
    public static bool _soundOn;
    private float cameraXRotation = 0f;

    public static int Stanza = 0;
    public static bool stop = false;

    [SerializeField] GameObject _person;
    private Animator _animator;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _footSound = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked;

        _position = 0;

        _animator = _person.GetComponent<Animator>();
    }


    void Update() {

        UpdateCursorLock();

        if (!stop)
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

            //Compute direction According to Camera Orientation
            transform.Rotate(Vector3.up, mouseX);
            cameraXRotation -= mouseY;
            cameraXRotation = Mathf.Clamp(cameraXRotation, -90f, 90f);
            _cameraT.localRotation = Quaternion.Euler(cameraXRotation, 0f, 0f);

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 move = (transform.right * h + transform.forward * v).normalized;
            _characterController.Move(move * _speed * Time.deltaTime);

            //Is Walking?
            float x = Mathf.Abs(_characterController.velocity.x);
            float y = Mathf.Abs(_characterController.velocity.y);
            float z = Mathf.Abs(_characterController.velocity.z);

            if (_position != (x + y + z))
            {
                _position = (x + y + z);
                PlayFootStepAudio(true);
                if (_animator == null) return;
                _animator.SetBool("isWalking", true);
            }
            else
            {
                PlayFootStepAudio(false);
                if (_animator == null) return;
                _animator.SetBool("isWalking", false);
            }

        }
        else
        {
            PlayFootStepAudio(false);
            if (_animator == null) return;
            _animator.SetBool("isWalking", false);
        }        
    }

    public void UpdateCursorLock()
    {
        if (!stop)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (stop)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void PlayFootStepAudio(bool flag)
    {
        if (flag==true)
        {
            if (!_soundOn)
            {
                
                _footSound.Play();
                _soundOn = true;
            }
        }
        else
        {
            _footSound.Stop();
            _soundOn = false;
        }

    }



}
