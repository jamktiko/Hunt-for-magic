﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlime : MonoBehaviour
{
    private bool _slowed;
    private bool DamageDealt;

    [SerializeField]
    private float _playerSpeed = 2.5f;
    private float _damageAmount = 10f;

    private void Update()
    {
        Invoke("MovementReturn", 5f);
        DamageOff();
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _slowed == false)
        {
            other.GetComponent<PlayerCharacterController>().speed /= 2f;

            _slowed = true;

            if (this.gameObject.name =="SlowingSlimeCharge" && !DamageDealt)
            {
                var enemy = other.gameObject.GetComponent<Rigidbody>();

                var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

                 if (enemy != null)
                 {
                 DamageDealt = true;
                 enemyHealth.AddDamage(_damageAmount);
                 }

            }
            else
            {

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && _slowed == true)
        {
            MovementReturn();
        }
    }

    private void MovementReturn()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerCharacterController>().speed = _playerSpeed;

        _slowed = false;
    }

    IEnumerator DamageOff()
    {
        yield return new WaitForSeconds(1.1f);
        DamageDealt = true;
    }
}
