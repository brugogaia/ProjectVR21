using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumina : MonoBehaviour
{
    private GameObject Player;
    private Color original;
    private float Red;
    private float Green;
    private float Blue;
    private float MaxDist = 10f;
    // Start is called before the first frame update
    void Start()
    {
        original = gameObject.GetComponent<Renderer>().material.color;
        Red = original.r;
        Green = original.g;
        Blue = original.b;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayPos=Player.transform.position;
        Vector3 Pos = transform.position;
        float Distance = Vector3.Distance(PlayPos, Pos);
        if (Distance < MaxDist)
        {
            Color Shiny = new Color(Red+(255f-Red)*(MaxDist-Distance)/MaxDist,Green+(255f-Green)*(MaxDist-Distance)/MaxDist,Blue+(255f-Blue)*(MaxDist-Distance)/MaxDist); 
            Color newCol = Color.Lerp(original, Shiny, 0.01f);
            gameObject.GetComponent<Renderer>().material.color=newCol;
        }
        else
            gameObject.GetComponent<Renderer>().material.color=original;
    }
}
