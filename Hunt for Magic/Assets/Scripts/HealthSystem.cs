﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float _health = 100;

    [SerializeField]
    public float _maxHealth = 100;

    public float health => _health;

    public bool _damageTaken;


    public void AddDamage(float damage)
    {
        if (gameObject.tag == "Player" && gameObject.GetComponent<Dodgedash>()._dodgeDash)
        {
            damage = 0;
        }

            _health -= damage;

        if (gameObject.tag == "Player")
        {
            _damageTaken = true;

            Invoke("DamageOff", 0.5f);
        }

        if (_health <= 0)
        {
            _health = 0;

            if (gameObject.name.Contains("EnemySlimePrefab"))
            {
                gameObject.GetComponent<EnemySlimeMovement>().enabled = false;
            }    

            Destroy(gameObject, 2f);   //2 sekuntia aikaa kuolinanimaatiolle
        }
    }

    private void DamageOff()
    {
        _damageTaken = false;
    }
}
