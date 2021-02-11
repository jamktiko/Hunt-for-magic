using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDebuff : MonoBehaviour  //Tämä scripti liitetään vihollisiin
{
    [SerializeField]
    private float _debuffDamage = 0.01f;

    [SerializeField]
    private bool _onFire;

    private HealthSystem _healthSystem;

    [SerializeField]
    private GameObject _onFirePrefab;

    // Start is called before the first frame update
    void Start()
    {
        _onFire = false;
        _healthSystem = gameObject.GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_onFire)
        {
            StartCoroutine("FireDamage");
        }
    }

    IEnumerator FireDamage()
    {
        int i = 0;

        while (i < 4)
        {
            yield return new WaitForSeconds(1f);
            Repeat();
            i++;
        }

        _onFire = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (_onFire != true && other.tag != "Player")
        {
            _onFire = true;
        }
    }

    private void Repeat()
    {
        _healthSystem.AddDamage(_debuffDamage);
    }
}
