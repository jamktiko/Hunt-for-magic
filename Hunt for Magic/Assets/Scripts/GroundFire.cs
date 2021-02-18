using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFire : MonoBehaviour
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
        
    }

    private void OnParticleCollision(GameObject other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null && enemy.name != "PlayerCharacter")
        {
            enemyHealth.AddDamage(_damageAmount);
            other.GetComponent<FireDebuff>()._onFire = true;
        }
    }
}
