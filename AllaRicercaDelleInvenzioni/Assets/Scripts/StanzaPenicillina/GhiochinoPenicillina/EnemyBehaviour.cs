using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public static float _speed = 5;
    public GameObject _particles;
    public AudioClip _explosion;
    public AudioClip _damage;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Timer._timerFloat -= 3f;
            AudioSource.PlayClipAtPoint(_damage, transform.position);
            EnemyBehaviour._speed -= 1f;
            Destroy(gameObject);
        }
        else if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            GameObject Particles = Instantiate(_particles, transform.position, Quaternion.identity);
            Particles.GetComponent<ParticleSystem>().Play();
            Timer._timerFloat += 3f;
            AudioSource.PlayClipAtPoint(_explosion, transform.position);
            EnemyBehaviour._speed += 2f;
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -20.0f)
        {
            Debug.Log("Prova");
            Timer._timerFloat -= 3f;
            AudioSource.PlayClipAtPoint(_damage, transform.position);
            EnemyBehaviour._speed -= 1f;
            Destroy(gameObject);
        }
        transform.Translate(transform.right*_speed*Time.deltaTime, Space.World);
    }
}

