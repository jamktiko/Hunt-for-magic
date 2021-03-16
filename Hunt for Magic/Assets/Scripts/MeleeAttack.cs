﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public static bool _isAttackOnCooldown;

    [SerializeField]
    private float _damage = 5f;


    [SerializeField]
    public float _cooldown = 1.16f;

    [SerializeField]
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _isAttackOnCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            if (_isAttackOnCooldown)
                return;

            _anim.SetTrigger("Melee");

            _isAttackOnCooldown = true;
            Invoke("EndAttackCooldown", _cooldown);
        }
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