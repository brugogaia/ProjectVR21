using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumina : MonoBehaviour
{
    private GameObject Player;
    private Color original;
    private Material[] renderers;
    private Material Bordino;
    private float Red;
    private float Green;
    private float Blue;
    private float MaxDist = 5f;
    // Start is called before the first frame update
    void Start()
    {
        renderers = gameObject.GetComponent<Renderer>().materials ;
        foreach (Material ren in renderers) {
            Debug.LogWarning(renderers.Length);
            if (ren.name.Contains("bordino"))
            {
                original = ren.color;
                Bordino = ren;
                break;
            }
        }
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
            Color Shiny = new Color(Red + (255f - Red) * (MaxDist - Distance) / MaxDist, Green + (255f - Green) * (MaxDist - Distance) / MaxDist, Blue + (255f - Blue) * (MaxDist - Distance) / MaxDist);
            Color newCol = Color.Lerp(original, Shiny, 0.03f);
            Bordino.color = newCol;
            gameObject.GetComponent<Renderer>().material.color = newCol;
        }
        else
        {
            Bordino.color = original;
            gameObject.GetComponent<Renderer>().material.color = original;
        }
    }
}
