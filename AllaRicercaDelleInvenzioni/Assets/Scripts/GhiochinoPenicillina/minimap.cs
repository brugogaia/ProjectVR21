using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    private bool End= false;
    private float SpacePercorred=0;
    private Vector3 OriginPos; 
    
    // Start is called before the first frame update
    void Start()
    {
        OriginPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            if (!End)
                transform.Translate(Vector3.right * Time.deltaTime * 3.16f);
            SpacePercorred += Time.deltaTime * 3.16f;
            if (SpacePercorred > 190 - 38.8)
                End = true;
        }
    }


    public void resetMinimap() {
        transform.position = OriginPos;
        SpacePercorred = 0f;
        End = false;
    }
}
