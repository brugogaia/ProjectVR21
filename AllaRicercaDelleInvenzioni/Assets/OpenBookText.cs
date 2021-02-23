using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBookText : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject[] _text;
    private RayCast _ray;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject t in _text) t.SetActive(false);
        index = PlayerPrefs.GetInt("Progress");
    }

    // Update is called once per frame
    void Update()
    {
        _ray = _player.GetComponent<RayCast>();
        if (index > _text.Length)
        {
            if (_ray._raycasted != null)
            {
                if ((_ray._raycasted.name == this.name))
                {
                    _text[index].SetActive(true);
                }
                else
                {
                    _text[index].SetActive(false);
                }
            }
            else
            {
                _text[index].SetActive(false);

            }
        }
            
    }
}
