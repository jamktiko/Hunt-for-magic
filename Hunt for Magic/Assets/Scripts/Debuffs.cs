using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuffs : MonoBehaviour
{
    [SerializeField]
    public bool _wet;

    [SerializeField]
    public bool _chilled;

    [SerializeField]
    public bool _onFire;

    [SerializeField]
    public bool _shocked;

    [SerializeField]
    public bool _oily;

    public float _debuffDamage = 0.01f;

    private HealthSystem _healthSystem;

    [HideInInspector]
    public bool _stunned;

    [SerializeField]
    private GameObject _wetEffect;

    [SerializeField]
    private GameObject _onFireEffect;

    private void Start()
    {
        _onFire = false;
        _healthSystem = gameObject.GetComponent<HealthSystem>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_chilled)
        {
            StartCoroutine("ChillStopper");
        }

        if (_wet)
        {
            _onFire = false;
            _wetEffect.SetActive(true);
            StartCoroutine("WaterStopper");
        }

        if (_onFire)
        {
            _onFireEffect.SetActive(true);
            StartCoroutine("FireDamage");
        }

        if (_shocked)
        {
            StartCoroutine("ShockStopper");
        }

        if (_stunned)
        {
            StartCoroutine("StunStopper");
        }

        if (_oily)
        {
            StartCoroutine("OilStopper");
        }
    }

    IEnumerator FireDamage()
    {
        int i = 0;

        while (i < 5 && _onFire == true)
        {
            yield return new WaitForSeconds(1f);
            Repeat();
            i++;
        }

        _onFire = false;
        _onFireEffect.SetActive(false);
    }

    private void Repeat()
    {
        _healthSystem.AddDamage(_debuffDamage);
    }

    IEnumerator ChillStopper()
    {
        int i = 0;

        while (i < 8 && _chilled == true)
        {
            yield return new WaitForSeconds(1f);
            i++;
        }

        _chilled = false;
    }

    IEnumerator WaterStopper()
    {
        int i = 0;

        while (i < 10 && _wet == true)
        {
            yield return new WaitForSeconds(1f);
            i++;
        }

        _wet = false;
        _wetEffect.SetActive(false);
    }

    IEnumerator ShockStopper()
    {
        int i = 0;

        while (i < 10 && _shocked == true)
        {
            yield return new WaitForSeconds(1f);
            i++;
        }

        _shocked = false;
    }

    IEnumerator StunStopper()
    {
        if (GetComponent<EnemySlimeMovement>().enabled)
        {
            GetComponent<EnemySlimeMovement>().speed = 0;

            yield return new WaitForSeconds(1f);

            GetComponent<EnemySlimeMovement>().speed = 3;
        }

        _stunned = false;
    }

    IEnumerator OilStopper()
    {
        int i = 0;

        while (i < 8 && _oily == true)
        {
            yield return new WaitForSeconds(1f);
            i++;
        }

        _oily = false;
    }
}