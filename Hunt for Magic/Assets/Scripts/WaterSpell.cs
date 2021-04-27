﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;
    private float _baseDamage = 15f;
    private float WaterBonus;
    private float _speed = 5f;

    private Transform _waterCastingPoint;
    private Vector3 scaleChange, positionChange;

    private Object _waterPool;
    public GameObject _player;
    public SphereCollider _waterSpellCollider;
    private Object _waterHit;


    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        WaterBonus = _player.GetComponent<CrystalScript>().airBonus;
        _damageAmount = _baseDamage + WaterBonus;
        _waterCastingPoint = GameObject.Find("WaterCastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_waterCastingPoint.forward * _speed, ForceMode.Impulse);
        gameObject.GetComponent<SphereCollider>();
        scaleChange = new Vector3(-0.01f, 0.02f, 0);
        positionChange = new Vector3(0, -0.0001f, 0);
        StartCoroutine(DamageFizzle());
        _waterPool = Resources.Load("Prefabs/GroundWater");
        _waterHit = Resources.Load("Prefabs/OnHitwater");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Object.Destroy(gameObject, 6.0f);
        if (Time.timeScale == 1)
        {
            if (_waterSpellCollider != null)
            {
                _waterSpellCollider.transform.localScale += scaleChange;
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        if (enemy != null && enemy.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            var enemy = other.gameObject.GetComponent<Rigidbody>();

            var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

            if (enemy != null && enemy.tag == "Monster")
            {
                enemyHealth.AddDamage(_damageAmount);
                other.gameObject.GetComponent<Debuffs>()._wet = true;

                Object groundWater = Instantiate(_waterPool, transform.TransformPoint(0, -1.28f, 0), Quaternion.identity);
                Destroy(groundWater, 5f);

                Object onHitwater = Instantiate(_waterHit, transform.position, Quaternion.identity);
                Destroy(onHitwater, 1f);
            }
        }

        if (other.tag == "Wall")
        {
            Destroy(gameObject.GetComponentInParent<ParticleSystem>());
            Destroy(gameObject);
        }
    }

    IEnumerator DamageFizzle()
    {
        while (_damageAmount > 5 && Time.timeScale == 1)
        {
            yield return new WaitForSeconds(0.5f);
            if (_damageAmount > 10)
            {
                _damageAmount -= 1f;
            }
        }
    }
}
