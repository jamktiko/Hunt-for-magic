﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public GameObject _victoryPanel;
    [SerializeField]
    private Button _mainMenu;

    private GameObject _player;

    private GameObject _crosshair;

    public AudioSource _menuSrc;
    public AudioClip _menuClick;
    public GameObject[] SpellPickups;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _crosshair = GameObject.Find("Crosshair");

        _mainMenu.onClick.AddListener(MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        SpellPickups = GameObject.FindGameObjectsWithTag("Pickup");
    }
    private void MainMenu()
    {
        _menuSrc.PlayOneShot(_menuClick);
        _victoryPanel.SetActive(false);
        _player.GetComponent<PlayerCharacterController>().enabled = true;
        _player.GetComponentInChildren<PlayerAnimation>().enabled = true;
        _player.GetComponent<SpellCasting>().enabled = true;
        _player.GetComponent<PlayerSounds>().enabled = true;
        _crosshair.SetActive(true);

        foreach (GameObject spell in SpellPickups)
        {
            if (spell != null)
            {
                spell.GetComponent<PickupText>()._text.enabled = true;
            }
        }

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}