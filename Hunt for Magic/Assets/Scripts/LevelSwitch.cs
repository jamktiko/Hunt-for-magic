using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    public GameObject _player;
    public GameObject _hud;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _hud = GameObject.Find("HUD");

    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DontDestroyOnLoad(_player);
            DontDestroyOnLoad(_hud);
            SceneManager.LoadScene(3);
        }
    }
}
