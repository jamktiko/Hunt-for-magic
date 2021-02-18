using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpell : MonoBehaviour
{
    [SerializeField]
    private static float _damageAmount = 15f;
    private float _speed = 5f;

    private Transform _waterCastingPoint;
    void Start()
    {

        _waterCastingPoint = GameObject.Find("WaterCastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_waterCastingPoint.forward * _speed, ForceMode.Impulse);
        StartCoroutine(DamageFizzle());
    }

    // Update is called once per frame
    void Update()
    {
        Object.Destroy(gameObject, 15.0f);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            var enemy = other.gameObject.GetComponent<Rigidbody>();

            var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

            if (enemy != null)
            {
                enemyHealth.AddDamage(_damageAmount);
                other.GetComponent<WetDebuff>()._wet = true;
                other.GetComponent<FireDebuff>()._onFire = false;
            }
        }
    }

    static IEnumerator DamageFizzle()
    {
        yield return new WaitForSeconds(1);
        if (_damageAmount > 0)
        {
            _damageAmount -= 1;
        }
    }
}
