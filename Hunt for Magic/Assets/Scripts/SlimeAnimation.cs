using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    public Animator _anim;

    private Rigidbody _slime;

    [HideInInspector]
    public bool _chargeAttack;

    private Object _slimeExplosion;

    // Start is called before the first frame update
    void Start()
    {
        _slime = gameObject.GetComponentInParent<Rigidbody>();
        _anim = _slime.GetComponentInChildren<Animator>();
        _slimeExplosion = Resources.Load("Prefabs/SlimeExplosion");
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
            Object explosion = Instantiate(_slimeExplosion, _slime.position, Quaternion.Euler(90, 0, 0));
            Destroy(explosion, 2f);
        }

        if (_slime.GetComponent<HealthSystem>().health == 0)
        {
            _anim.Play("SlimeDeath");
        }
    }
}
