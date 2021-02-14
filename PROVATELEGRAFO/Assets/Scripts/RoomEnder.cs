using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnder : MonoBehaviour
{
    [SerializeField] private int _stanza;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Progress", _stanza);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
