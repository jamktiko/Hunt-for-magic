using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{

    [SerializeField]
    private float _damageAmount = 0.01f;

    // Start is called before the first frame update
    void Start()
    {

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

        if (other.GetComponent<WetDebuff>()._wet == true)
            _damageAmount *= 0.5f;

        if (enemy != null && enemy.name != "PlayerCharacter")
        {
            enemyHealth.AddDamage(_damageAmount);
            other.GetComponent<FireDebuff>()._onFire = true;
        }
    }
}