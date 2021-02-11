using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount = 1f;
    private float maxCount = 3;
    private float ammoChanger = 1;
    private float chargeCounter = 0;
    private float chargeBoost = 1.3f;
    private float currentAmmo;
    private float actualDamage;
    private bool chargeHold = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Object.Destroy(gameObject, 0.5f);
        if (Input.GetMouseButtonDown(0))
        {
            chargeHold = true;
        }
        else
        {
            chargeHold = false;
            actualDamage = _damageAmount * chargeCounter * chargeBoost;
            chargeCounter = 0;
        }
    }

    private void spellCharger()
    {
        
        for (int i = 0; i <= currentAmmo; i++)
        {
            if (chargeHold)
            {
                chargeCounter = chargeCounter + 1;
                chargeDelay(chargeCounter);
            }
        }
    }
    private void OnCollisionEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null)
        {
            currentAmmo = currentAmmo - ammoChanger;
            _damageAmount = actualDamage;
            enemyHealth.AddDamage(_damageAmount);
            Destroy(gameObject);
        }
    }

    IEnumerator chargeDelay(float chargeCounter)
    {
        yield return new WaitForSeconds(1.2f);
        if (chargeCounter == currentAmmo)
        {
            currentAmmo = currentAmmo - chargeCounter;
        }
        else chargeCounter++;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2.4f);
        currentAmmo = currentAmmo + ammoChanger;
        yield return currentAmmo;
    }
}