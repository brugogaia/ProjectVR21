using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAndRiddles : MonoBehaviour
{
    [SerializeField] private GameObject[] quiz;
    public GameObject quiz_empty;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject q in quiz) q.SetActive(false);
        quiz_empty.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
