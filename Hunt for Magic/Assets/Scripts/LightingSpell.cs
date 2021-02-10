using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount = 1f;
    private float ammoCount = 3;
    private float ammoChanger = 1;
    private float chargeCounter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Object.Destroy(gameObject, 0.5f);
    }


    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null)
        {
            ammoCount = ammoCount - ammoChanger;
            enemyHealth.AddDamage(_damageAmount);
            Destroy(gameObject);
        }
    }
}