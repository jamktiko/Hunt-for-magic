using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlime : MonoBehaviour
{
    private bool _slowed;
    private bool DamageDealt;

    [SerializeField]
    private float _playerSpeed = 2.5f;
    private float _damageAmount = 25f;

    private void Update()
    {
        Invoke("MovementReturn", 5f);
        if (!DamageDealt)
        {
            DamageOff();
        }
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _slowed == false)
        {
            other.GetComponent<PlayerCharacterController>().speed = _playerSpeed / 2f;

            _slowed = true;

            if (gameObject.name.Contains("SlowingSlimeCharge") && !DamageDealt)
            {
               var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

                DamageDealt = true;
                enemyHealth.AddDamage(_damageAmount);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && _slowed == true)
        {
            MovementReturn();
        }
    }

    private void MovementReturn()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerCharacterController>().speed = _playerSpeed;

        _slowed = false;
    }

    IEnumerator DamageOff()
    {
        yield return new WaitForSeconds(1.8f);
        DamageDealt = true;
    }
}
