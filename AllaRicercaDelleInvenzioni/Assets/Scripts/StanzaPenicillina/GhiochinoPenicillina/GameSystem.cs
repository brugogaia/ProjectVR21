using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private float _time = 2.0f;
    public static  bool _startFlag = false;
    public static bool GameStart = false;
    public static bool GameOver = false;
    public GameObject _enemy;
    public GameObject _chara;
    public GameObject _boss;
    public Camera _mainCamera;
    public GameObject _gameOverScreen;
    public GameObject[] _UI;
    public minimap _cursor;
    private int nOfBacteria = 0;
    private float OriginalSpeed;
    void Start()
    {
        PlayerPrefs.SetInt("Cura", 0);
        OriginalSpeed = EnemyBehaviour._speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (_startFlag) {
            Debug.Log("I'm here");
            GameStart = true;
            foreach (GameObject item in _UI) {
                item.SetActive(true);
            }
            _startFlag = false;

        }
        if(GameStart)
        {
            if (Timer._timerFloat < 0f)
            {
                _gameOverScreen.SetActive(true);
                GameStart = false;
            }
            else
            {
                _time -= Time.deltaTime;
                if (_time < 0.0f && nOfBacteria <= 10)
                {
                    spawnBacteria();
                    _time = 2.0f;
                }
                else if (_time < 0.0f && nOfBacteria > 10)
                {
                    spawnBoss();
                    _time = 1000f;
                }
            }
        }
        if (GameOver) {
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in Enemies) {
                Destroy(enemy);
            }
            GameOver = false;
            GameStart = true;
            nOfBacteria = 0;
            _cursor.resetMinimap();
            Timer._timerFloat = 60f;
            _time = 3f;
            EnemyBehaviour._speed = OriginalSpeed;
        }
            
    }

    void spawnBacteria()
    {
        Vector3 spawnpoint = new Vector3(Random.Range(20f,26f), Random.Range(-13.0f, 13.0f), _chara.transform.position.z);

        GameObject Bactertia = Instantiate(_enemy, spawnpoint, Quaternion.LookRotation(Vector3.forward,_chara.transform.position- spawnpoint)*Quaternion.Euler(0f,0f,90f));
        nOfBacteria++;

    }

    void spawnBoss()
    {
        Vector3 spawnpoint = new Vector3(Random.Range(0f, 13f), 0, _chara.transform.position.z);
        for (int i = 0; i < 5; i++)
            spawnBacteria();
        GameObject Bactertia = Instantiate(_boss, spawnpoint, Quaternion.identity);

    }
}
