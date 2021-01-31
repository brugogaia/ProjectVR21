using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyFPC : MonoBehaviour
{
    [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _mouseSensitivity = 100f;

    private CharacterController _characterController;
    private float cameraXRotation = 0f;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update() { 

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
    }
}
