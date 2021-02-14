using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnimation : MonoBehaviour
{
    public PrintGutenberg libro_pressa;
    private Animator anim;
    public GameObject text;
    [SerializeField] private GameObject _exit;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        text.SetActive(false);
        _exit.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (libro_pressa.libro_move)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("press", true);
                libro_pressa.fine_anim_stampa = true;
                StartCoroutine(Exit());
                
            }
                
        }
        
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(0.8f);
        text.SetActive(true);
        _exit.SetActive(true);
    }
}
