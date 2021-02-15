using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    private GameObject Player;
    private AudioSource bip;
    private float MaxDist = 7f;
    private bool playstart;
    private float d;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        bip = gameObject.GetComponent<AudioSource>();
        bip.volume = 0;
        playstart = false;
        d = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playstart)
        {
            bip.Play();
            playstart = true;
        }
        else
        {
            Vector3 PlayPos = Player.transform.position;
            Vector3 Pos = transform.position;
            float Distance = Vector3.Distance(PlayPos, Pos);

            if (Distance < MaxDist)
            {
               if (d > Distance) {
                    d = Distance;
                    bip.volume += 1 * (MaxDist - Distance) / 1000;
               }else if (d < Distance)
                {
                    d = Distance;
                    bip.volume -= 1 * (MaxDist - Distance) / 1000;
               }else if (d == 0)
                {
                    d = Distance;
                }
                
            }
            else
            {
                bip.volume = 0;
            }
        }
        
        

    }
}
