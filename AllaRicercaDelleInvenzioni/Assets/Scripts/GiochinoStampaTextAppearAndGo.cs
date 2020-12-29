using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiochinoStampaTextAppearAndGo : MonoBehaviour
{
    private bool entrato = false;
    public GameObject canva1;
    public GameObject canva2;
    public GameObject text1;

    // Start is called before the first frame update
    void Start()
    {
        canva1.SetActive(false);
        canva2.SetActive(false);
        text1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {  
        if (entrato)
        {
            Debug.Log("ENTRATO");
            text1.SetActive(true);

            if (Input.GetMouseButtonDown(1))
            {
                text1.SetActive(false);
                canva1.SetActive(true);
                canva2.SetActive(false);
            }
        }
        if (!entrato)
        {
            text1.SetActive(false);
        }
        
    }

    private void OnCollisionEnter(Collision player)
    {
        Debug.Log("ENTRATO c");
        if (player.gameObject.tag=="Player")
        {
            Debug.Log("ENTRATO P");
            entrato = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            entrato = false;
        }
    }
}
