using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwithcer : MonoBehaviour
{
    [SerializeField] private GameObject[] _menues;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject menu in _menues)
            menu.SetActive(false);
        _menues[PlayerPrefs.GetInt("Progress")].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
