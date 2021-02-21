using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BokkDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameBooks;
    private bool book_active;
    // Start is called before the first frame update
    void Start()
    {
        book_active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (book_active)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("Progress"); i++)
            {
                _gameBooks[i].SetActive(true);
                _gameBooks[i].GetComponent<SceneChanger>().enabled = false;
            }
            book_active = false;
        } 
    }
}
