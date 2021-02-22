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

    private float _debuffDamage = 0.01f;

    private HealthSystem _healthSystem;

    private GameObject _onFirePrefab;

    private void Start()
    {
        _onFire = false;
        _healthSystem = gameObject.GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_chilled == true)
        {
            StartCoroutine("ChillStopper");
        }

        if (_wet == true)
        {
            StartCoroutine("WaterStopper");
        }

        if (_onFire)
        {
            StartCoroutine("FireDamage");
        }

        if (_shocked)
        {
            StartCoroutine("ShockStopper");
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
}