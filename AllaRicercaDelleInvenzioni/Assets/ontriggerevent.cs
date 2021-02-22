using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ontriggerevent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<RoomEnder>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
