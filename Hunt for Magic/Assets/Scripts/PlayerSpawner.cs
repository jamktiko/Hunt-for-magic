﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    private GameObject _player;
    private GameObject _hud;

    // Start is called before the first frame update
    void Start()
    {
        _hud = GameObject.Find("HUD");
        _player = GameObject.FindWithTag("Player");
        _player.transform.position = gameObject.transform.position;

        SceneManager.MoveGameObjectToScene(_player, SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(_hud, SceneManager.GetActiveScene());
    }
}
