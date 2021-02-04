using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float _health = 100;

    [SerializeField]
    public float _maxHealth = 100;

    public float health => _health;

    public void AddDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;

            Destroy(gameObject);
        }
    }
}
