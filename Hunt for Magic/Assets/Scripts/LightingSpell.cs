using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount = 15f;
    private bool chargeHold = false;
    private Transform _castingPoint;
    private float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        spellCharger();
        Destroy(gameObject, 0.7f);
    }

    private void OnTriggerEnter(Collider other)

    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null)
        {
            enemyHealth.AddDamage(_damageAmount);
            Destroy(gameObject);
        }
    }

    private void spellCharger()
    {
        chargeHold = true;
            if (chargeHold)
            {
                Cooldown();
                chargeHold = false;
            }
            else chargeHold = false;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2.4f);
    }
}