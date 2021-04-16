using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{

    [SerializeField]
    public float _damageAmount;

    private float _wetDamageAmount;

    // Start is called before the first frame update
    void Start()
    {
        var FireBonus = GameObject.FindGameObjectWithTag("Player").GetComponent<CrystalScript>().fireDamage;
        _damageAmount = FireBonus;
        _wetDamageAmount = _damageAmount * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        Destroy(gameObject, 3f);

    }

    private void OnParticleCollision(GameObject other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null && enemy.tag == "Monster")
        {
            if (enemy.GetComponent<Debuffs>()._wet == true)
            {
                _damageAmount = _wetDamageAmount;
            }

            enemyHealth.AddDamage(_damageAmount);
            other.GetComponent<Debuffs>()._onFire = true;
        }
    }
}