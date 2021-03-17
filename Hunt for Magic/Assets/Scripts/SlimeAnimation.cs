using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    public Animator _anim;

    private Rigidbody _slime;

    [HideInInspector]
    public bool _chargeAttack;

    // Start is called before the first frame update
    void Start()
    {
        _slime = gameObject.GetComponentInParent<Rigidbody>();
        _anim = _slime.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_slime.velocity != Vector3.zero)
        {
            _anim.SetBool("Jump", true);
        }

        if (_slime.velocity == Vector3.zero)
        {
            _anim.SetBool("Jump", false);
        }

        if (_chargeAttack)
        {
            _chargeAttack = false;
            _anim.Play("SlimeCharged");
        }

        if (_slime.GetComponent<HealthSystem>().health == 0)
        {
            _anim.Play("SlimeDeath");
        }
    }
}
