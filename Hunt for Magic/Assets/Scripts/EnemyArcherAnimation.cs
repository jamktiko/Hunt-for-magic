using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherAnimation : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _anim;
    private HealthSystem _hs;
    private EnemyArcherMovement _movement;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = gameObject.GetComponentInParent<Rigidbody>();
        _hs = GetComponentInParent<HealthSystem>();
        _movement = GetComponentInParent<EnemyArcherMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_movement.running)
        {
            _anim.SetBool("Running", true);
            _anim.SetFloat("RunSpeed", 1.3f);
        }
        else if (_movement.patrol || _movement.strafe || (_movement.inRange && !_movement.attackRange))
        {
            _anim.SetBool("Running", true);
            _anim.SetFloat("RunSpeed", 1.0f);
        }
        else
        {
            _anim.SetBool("Running", false);
            _anim.SetFloat("RunSpeed", 1.0f);
        }

        if (_rb.velocity.y < -2)
        {
            _anim.SetBool("Falling", true);
        }
        else
        {
            _anim.SetBool("Falling", false);
        }

        if (_movement.isAttacking && !_movement.strafe && !_movement.running)
        {
            _anim.SetBool("Shooting", true);
        }
        else if (_movement.attackRange && !_movement.isAttacking && !_movement.attackCommence)
        {
            _anim.SetBool("RepeatShooting", true);
        }
        else
        {
            _anim.SetBool("Shooting", false);
            _anim.SetBool("RepeatShooting", false);
        }

        if (_hs.health == 0)
        {
            _anim.SetTrigger("Death");
        }
    }
}
