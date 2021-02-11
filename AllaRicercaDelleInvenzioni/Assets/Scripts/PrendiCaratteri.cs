using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrendiCaratteri : MonoBehaviour
{
    private bool entrato = false;
    public GameObject text1;
    public GiochinoStampa fineGiocoTrue;
    public PrintGutenberg script_pressa;

    //RigidbodyFirstPersonController scriptFP = null;



    // Start is called before the first frame update
    void Start()
    {
        text1.SetActive(false);
             
        // GameObject tempObj = GameObject.Find("RigidBodyFPSController");
        // scriptFP = tempObj.GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (entrato && fineGiocoTrue.fineGioco && !script_pressa.libro_move)
        {
            //Debug.Log("ENTRATO NEI CARATTERI");
            text1.SetActive(true);

            

        }
        if (!entrato && fineGiocoTrue.fineGioco)
        {
            //Debug.Log("Fuori DAI CARATTERI");
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
