using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed = 0.0f;
    public GameObject _shoot;
    public AudioSource _audioShot;

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        float movementY = Input.GetAxis("Vertical");
        transform.Translate(0,movementY*_speed*Time.deltaTime,0);

        //float movementX = Input.GetAxis("Horizontal");
        //transform.Translate(movementX * speed * Time.deltaTime,0, 0);
        Vector3 pos = transform.position;
        pos.x += 0.5f;
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject bullet = Instantiate(_shoot, pos, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_audioShot.clip, transform.position);
        }

    }
}
