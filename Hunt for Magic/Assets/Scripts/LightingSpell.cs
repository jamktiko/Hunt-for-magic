﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingSpell : MonoBehaviour
{
    [SerializeField]
    public float _damageAmount = 15f;
    private bool chargeHold = false;
    private Transform _castingPoint;
    private float speed = 50f;
    private Object _elecHit;

    // Start is called before the first frame update
    void Start()
    {
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        _elecHit = Resources.Load("Prefabs/OnHitElec");
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        spellCharger();
        Destroy(gameObject, 0.7f);
    }

    private void OnTriggerEnter(Collider other)

    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null)
        {
            if (other.GetComponent<Debuffs>()._wet == true)
            {
                _damageAmount *= 1.5f;
            }

            enemyHealth.AddDamage(_damageAmount);
            other.GetComponent<Debuffs>()._shocked = true;

            Object onHitElec = Instantiate(_elecHit, transform.position, Quaternion.identity);
            Destroy(onHitElec, 1f);

            Destroy(gameObject);
        }
    }

    private void spellCharger()
    {
        chargeHold = true;
            if (chargeHold)
            {
                Cooldown();
                chargeHold = false;
            }
            else chargeHold = false;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2.4f);
    }
}