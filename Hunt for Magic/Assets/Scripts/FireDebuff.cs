using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDebuff : MonoBehaviour  //Tämä scripti liitetään vihollisiin
{
    [SerializeField]
    private float _debuffDamage = 0.01f;

    [SerializeField]
    public bool _onFire;

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
}
