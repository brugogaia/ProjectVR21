using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarterTelegrafo : MonoBehaviour
{

	private GameObject tagGameObject;
	public Morse morse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
		tagGameObject=GameObject.FindGameObjectWithTag("StartGame");
		morse=tagGameObject.GetComponent<Morse>();
		morse.StartGioco=true;
    }

}
