using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrendiCaratteri : MonoBehaviour
{
    private bool entrato = false;
    public GameObject text1;
    public GiochinoStampa fineGiocoTrue;
    public PrintGutenberg script_pressa;

    // Start is called before the first frame update
    void Start()
    {
        text1.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (entrato && fineGiocoTrue.fineGioco && !script_pressa.libro_move &&!script_pressa.finecaratteri)
        {
            text1.SetActive(true);
        }
        else if (!entrato && fineGiocoTrue.fineGioco)
        {
            text1.SetActive(false);
        }
        else if ((script_pressa.finecaratteri)||(script_pressa.libro_move))
        {
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
