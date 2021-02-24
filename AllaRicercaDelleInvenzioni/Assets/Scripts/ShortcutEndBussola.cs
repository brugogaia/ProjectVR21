using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutEndBussola : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject _exitTrigger;
    void Start()
    {
        _exitTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) _exitTrigger.SetActive(true);
    }
}
