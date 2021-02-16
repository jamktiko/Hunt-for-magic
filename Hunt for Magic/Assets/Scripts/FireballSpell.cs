using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount = 5f;

    private GameObject _explosion;

    // Start is called before the first frame update
    void Start()
    {
        _explosion = Resources.Load<GameObject>("Prefabs/Explosion");
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
            Instantiate(_explosion, transform.position, Quaternion.identity);
        }
    }
}
