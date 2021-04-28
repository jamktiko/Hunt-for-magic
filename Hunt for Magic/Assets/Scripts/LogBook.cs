﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogBook : MonoBehaviour
{
    [SerializeField]
    private Button _challengesButton;
    [SerializeField]
    private Button _itemsButton;
    [SerializeField]
    private Button _enemiesButton;
    [SerializeField]
    private Button _arrowLeftButton;
    [SerializeField]
    private Button _arrowRightButton;
    [SerializeField]
    private Button _backButton;

    [SerializeField]
    private Image _itemGrid;
    public GameObject _mainMenu;
    public AudioSource _menuSrc;
    public AudioClip _menuClick;

    // Start is called before the first frame update
    void Start()
    {
        _backButton.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Back()
    {
        _menuSrc.PlayOneShot(_menuClick);
        gameObject.SetActive(false);
        _mainMenu.SetActive(true);
    }
    private void Items()
    {

    }
}
