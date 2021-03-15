﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    public static bool _isAttackOnCooldown;

    [SerializeField]
    private float _damage = 5f;

    public float _cooldown = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        _isAttackOnCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Fire2"))
        {
            if (_isAttackOnCooldown)
                return;

            other.GetComponent<HealthSystem>().AddDamage(_damage);

            _isAttackOnCooldown = true;

            Invoke("EndAttackCooldown", _cooldown);
        }
    }

    void EndAttackCooldown()
    {
        _isAttackOnCooldown = false;
    }
}