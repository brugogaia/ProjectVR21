using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChanger: MonoBehaviour
{
    [SerializeField] private string _target;
    [SerializeField] private bool _onInteraction;
    [SerializeField] private bool _onButton;
    [SerializeField] private bool _isStartMenu;
    [SerializeField] private Button _startButton;
    [SerializeField] private bool _autotrigger;
    [SerializeField] private bool _continue;
    [SerializeField] private Image _fade;
    private GameObject _player;
    private Animator _fadeAnim; 
    private Button _btn;


    // Start is called before the first frame update
    void Start()
    {

        

        if (_isStartMenu)
        {
            PlayerPrefs.SetInt("Progress", 0);
            PlayerPrefs.SetInt("Cura", 0);
            PlayerPrefs.SetInt("Frasi", 0);
            PlayerPrefs.SetInt("Biblioteca", 1);
        }
        if (_onButton)
        {
            if (_startButton != null)
            {
                _btn = _startButton.GetComponent<Button>();
                _btn.onClick.AddListener(Fade);
            }
        }
        if (_autotrigger)
            Fade();

    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
            Fade();
    }
    

    // Update is called once per frame
    void Update()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_onInteraction && Input.GetMouseButtonDown(0) && _player.GetComponent<RayCast>()._raycasted.Equals(gameObject))
            Fade();

    }

    private void TransferToScene()
    {
        if (_continue)
            Continue();
        if (!Menù.pausa)
        {
            
            {
                if (_target == "Biblioteca")
                    PlayerPrefs.SetInt("Biblioteca", 1);
                else
                    PlayerPrefs.SetInt("Biblioteca", 0);
                EasyFPC.stop = false;
                SceneManager.LoadScene(_target, LoadSceneMode.Single);
            }

            //GameObject Player = GameObject.FindGameObjectWithTag("Player");
        }
        
    }

    private void Continue() {
        if (EasyFPC.stop)
            EasyFPC.stop = false;
        Debug.Log(SceneUtility.GetScenePathByBuildIndex(PlayerPrefs.GetInt("Progress") + 1));
        Debug.Log(PlayerPrefs.GetInt("Progress"));
        Debug.Log(PlayerPrefs.GetInt("Biblioteca"));
        if (PlayerPrefs.GetInt("Biblioteca") == 0)
            SceneManager.LoadScene(SceneUtility.GetScenePathByBuildIndex(PlayerPrefs.GetInt("Progress")+1), LoadSceneMode.Single);
        else
            SceneManager.LoadScene("Biblioteca", LoadSceneMode.Single);

    }

    private void Fade() {
        if (_fade != null)
        {
            _fadeAnim = _fade.GetComponent<Animator>();
            StartCoroutine(Fading());
        }
        else
            TransferToScene();
    }

    IEnumerator Fading() {
        _fadeAnim.SetBool("Fade", true);
        yield return new WaitUntil( () => _fade.color.a == 1);
        TransferToScene();
    }
}

