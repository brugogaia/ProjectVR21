using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GiochinoStampaTextAppearAndGo : MonoBehaviour
{
    private bool entrato = false;
    private bool finetesto = false;
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
        if (entrato && !finetesto)
        {
            Debug.Log("ENTRATO");
            text1.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                finetesto = true;
                text1.SetActive(false);
                canva1.SetActive(true);
                canva2.SetActive(false);
                UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController._activeMovement = false;
                //scriptFP.mouseLook.lockCursor = false;//gameObject.mouse.lockCursor = false;
                //scriptFP.mouseLook.SetCursorLock(false);//mouseLook.SetCursorLock(false);
                               
            }
        }
        if (!entrato && !finetesto)
        {
            //Debug.Log("Fuori");
            text1.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider player)
    {
        
        if (player.gameObject.tag == "Player") 
        { 
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
