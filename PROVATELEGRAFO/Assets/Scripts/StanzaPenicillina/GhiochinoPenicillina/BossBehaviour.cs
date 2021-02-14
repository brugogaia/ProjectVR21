using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public static float _speed = 5;
    public GameObject _particles;
    private GameObject Chara;
    public GameObject _enemy;
    public AudioClip _explosion;
    public AudioClip _damage;
    private float ThisTimer = 1.0f;
    private int Life = 5;
    private int Direction = 1;
    private int DirSwitch = 4;

    void Start()
    {
        Chara = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
            Life--;
    }
    // Update is called once per frame
    void Update()
    {

        if (Life < 0)
        {

            AudioSource.PlayClipAtPoint(_explosion, transform.position);       

            GameObject Particles = Instantiate(_particles, transform.position, Quaternion.identity);
            Particles.GetComponent<ParticleSystem>().Play();
            PlayerPrefs.SetInt("Cura", 1);
            Chara.GetComponent<SceneChanger>().enabled = true;

            Destroy(gameObject);
        }

        Direction--;
        if (Direction == 0) {
            Direction = 100;
            DirSwitch = Random.Range(0, 3);
        }

        ThisTimer -= Time.deltaTime;
        if (ThisTimer < 0.0f) {
            spawnBacteria();
            ThisTimer = 1.0f;
        }

        /*switch (DirSwitch)
        {
            case 0:
                transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
                break;
            case 1:
                transform.Translate(transform.up * _speed * Time.deltaTime, Space.World);
                break;
            case 2:
                transform.Translate(-transform.right * _speed * Time.deltaTime, Space.World);
                break;
            case 3:
                transform.Translate(-transform.up * _speed * Time.deltaTime, Space.World);
                break;
            default:
                Direction = 1;
                break;
        }*/

    }

    void spawnBacteria()
    {
        Vector3 spawnpoint = new Vector3(transform.position.x, transform.position.y, Chara.transform.position.z);

        GameObject Bactertia = Instantiate(_enemy, spawnpoint, Quaternion.LookRotation(Vector3.forward, Chara.transform.position - spawnpoint) * Quaternion.Euler(0f, 0f, 90f));
    }
}

