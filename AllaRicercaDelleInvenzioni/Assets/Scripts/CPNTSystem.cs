using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPNTSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] Checkpoints;
    private GameObject Player;
    private int _progress;
    // Start is called before the first frame update
    void Start()
    {
        _progress = PlayerPrefs.GetInt("Progress");
        Player = GameObject.FindGameObjectWithTag("Player");
        if (_progress != 0) 
            Player.transform.position = Checkpoints[_progress-1].transform.position;
        Debug.LogError(_progress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
