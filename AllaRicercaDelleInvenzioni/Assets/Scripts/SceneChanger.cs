using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger: MonoBehaviour
{
    [SerializeField] private string _target;
    [SerializeField] private bool _standard;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider player)
    {
        SceneManager.LoadScene(_target, LoadSceneMode.Additive);

        SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("Player"), SceneManager.GetSceneByName(_target));
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
