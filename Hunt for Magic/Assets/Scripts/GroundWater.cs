using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundWater : MonoBehaviour
{
    [SerializeField]
    private bool _electric;

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        if (other.gameObject.name == "LightingSpellCollider")
        {
            _electric = true;
        }

        else if (enemy != null && enemy.tag == "Monster")
        {
            other.gameObject.GetComponent<Debuffs>()._wet = true;
        }

        if (other.tag == "Player")
        {
            other.GetComponent<PlayerSounds>()._onWater = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        if (enemy != null && enemy.tag == "Monster")
        {
            if (_electric == true)
            {
                enemy.GetComponent<HealthSystem>().AddDamage(0.1f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerSounds>()._onWater = false;
        }
    }

    private void OnDestroy()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerSounds>()._onWater = false;
    }
}