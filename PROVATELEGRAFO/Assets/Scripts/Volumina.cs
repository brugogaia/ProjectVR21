using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volumina : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    private AudioSource original;
    private float MaxDist = 50f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        original=gameObject.GetComponent<AudioSource>();
        original.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayPos = Player.transform.position;
        Vector3 Pos = transform.position;
        float Distance = Vector3.Distance(PlayPos, Pos);

        if (Distance < MaxDist)
        {
            float volume = (MaxDist - Distance) * 0.02f;
            original.volume = original.volume * volume;
        }
        else original.volume = 0;
            
    }
}
