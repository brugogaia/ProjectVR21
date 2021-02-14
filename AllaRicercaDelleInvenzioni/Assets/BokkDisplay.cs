using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BokkDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameBooks;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("Progress"); i++)
            _gameBooks[i].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
