﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DodgeCooldown : MonoBehaviour
{
    private static Image _cooldown;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _cooldown = GetComponent<Image>();
        _cooldown.fillAmount = 1.0f;
        _cooldown.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.GetComponent<Dodgedash>()._coolDown)
        {
            _cooldown.enabled = true;
            _cooldown.fillAmount -= 1.0f / 5.0f * Time.deltaTime;
        }
        else
        {
            _cooldown.enabled = false;
            _cooldown.fillAmount = 1.0f;
        }
    }
}
