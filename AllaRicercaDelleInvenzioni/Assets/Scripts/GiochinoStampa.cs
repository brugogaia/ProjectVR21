using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GiochinoStampa : MonoBehaviour
{
    string parola;
    string[] lista = new string[] { "bibbia", "stampa", "europa", "germania", "pergamena", "inchiostro", "incunaboli", "legametallica", "caratterimobili" };
    string listaI;
    int trovate_parole=0;
    GameObject[] gutenberg = new GameObject[9];
    float tempo = 3f;
    public GameObject canva1;
    public GameObject canva2;
    public GameObject errore;
    public bool fineGioco;
    //[SerializeField] public AudioSource[] audioYesorNot;
    private AudioSource audioYesorNot;

    //RigidbodyFirstPersonController scriptFP = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g1 = GameObject.Find("G1"); g1.SetActive(false); gutenberg[4] = g1;
        GameObject u1 = GameObject.Find("U1"); u1.SetActive(false); gutenberg[6] = u1;
        GameObject t1 = GameObject.Find("T1"); t1.SetActive(false); gutenberg[0] = t1;
        GameObject e1 = GameObject.Find("E1"); e1.SetActive(false); gutenberg[2] = e1;
        GameObject n1 = GameObject.Find("N1"); n1.SetActive(false); gutenberg[7] = n1;
        GameObject b1 = GameObject.Find("B1"); b1.SetActive(false); gutenberg[1] = b1;
        GameObject e2 = GameObject.Find("E2"); e2.SetActive(false); gutenberg[3] = e2;
        GameObject r1 = GameObject.Find("R1"); r1.SetActive(false); gutenberg[8] = r1;
        GameObject g2 = GameObject.Find("G2"); g2.SetActive(false); gutenberg[5] = g2;
        canva2.SetActive(false);
        errore.SetActive(false);
        fineGioco = false;
        EasyFPC.stop = true;
        audioYesorNot = GetComponent<AudioSource>();
        //for (int a = 0; a < audioYesorNot.Length; a++) audioYesorNot[a] = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(parola))
        {
            errore.SetActive(false);
            tempo = tempo - Time.deltaTime;
            for (int i = 0; i < lista.Length; i++)
            {
                if (parola.ToLower() == lista[i])
                {
                    audioYesorNot.Play();
                    Debug.Log("TROVATA " + parola);
                    trovate_parole++;

                    //inizializzo parola e cancello elemento array
                    listaI = lista[i];
                    this.ClearList(listaI);
                    this.ClearText();
                    this.AppearWord();
                    tempo = 3f;
                }
            }
            if(tempo<0f)
            {
                Debug.Log("ERRORE");
                this.ClearText();
                errore.SetActive(true);
                errore.GetComponent<AudioSource>().Play();
                tempo = 3f;
            }
        }

        if ((trovate_parole == 9)||(Input.GetKeyDown(KeyCode.P)))
        {
            
            canva1.SetActive(false);
            
            canva2.SetActive(true);
            canva2.GetComponent<AudioSource>().Play();
        }
    }

    public void CreateText(string letter)
    {
        parola = parola + letter;
        Text parolaComposta = GameObject.Find("ParolaComposta").GetComponent<Text>();
        parolaComposta.text = parola;
        tempo = 3f;
    }

    public void ClearText()
    {
        if (!string.IsNullOrEmpty(parola))
        {
            parola = parola.Remove(0);
            //Debug.Log(parola);
            Text parolaComposta = GameObject.Find("ParolaComposta").GetComponent<Text>();
            parolaComposta.text = parola;
        }
    }
            

    public void ClearLettera()
    {
        if (!string.IsNullOrEmpty(parola))
        {
            parola = parola.Remove(parola.Length - 1);
            //Debug.Log(parola);
            Text parolaComposta = GameObject.Find("ParolaComposta").GetComponent<Text>();
            parolaComposta.text = parola;
        }
            
    }

    public void ClearList(string text)
    {
        for (int i = 0; i < lista.Length; i++)
        {
            if (text == lista[i])
            {
                if (!string.IsNullOrEmpty(parola))
                {
                    lista[i] = lista[i].Remove(0);
                }
                    
            }
                
        }

    }

    public void AppearWord()
    {
        for (int i = 0; i < gutenberg.Length; i++)
        {
            if (!gutenberg[i].activeSelf)
            {
                gutenberg[i].SetActive(true);
                break;
            }
        }
    }

    public void EndGame()
    {
        UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController._activeMovement = true;
        //scriptFP.mouseLook.lockCursor = true;//gameObject.mouse.lockCursor = false;
        //scriptFP.mouseLook.SetCursorLock(true);//mouseLook.SetCursorLock(false);
        canva1.SetActive(false);
        canva2.SetActive(false);
        fineGioco = true;
        EasyFPC.stop = false;
    }
}
