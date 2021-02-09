using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed;
    private float _time = 5.00f;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        _time -= Time.deltaTime;
        transform.Translate(_speed * Time.deltaTime, 0, 0);
        if (_time < 0.0f)
            Destroy(gameObject);
    }
}
