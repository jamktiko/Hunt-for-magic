using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpell : MonoBehaviour  //Tämä scripti liitetään Tuulispellin prefabiin
{
    [SerializeField]
    private float _damageAmount = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Object.Destroy(gameObject, 0.5f);
    }

    private void OnParticleCollision(GameObject other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null)
        {
            enemy.AddForce(0, 1f, 1f, ForceMode.Impulse);
            enemyHealth.AddDamage(_damageAmount);
        }
    }
}
