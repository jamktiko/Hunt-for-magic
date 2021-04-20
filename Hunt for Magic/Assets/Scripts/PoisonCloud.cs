using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloud : MonoBehaviour
{
    private bool _cooldown;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!_cooldown)
            {
                other.GetComponent<HealthSystem>().AddDamage(2f);
                _cooldown = true;
                Invoke("CooldownEnd", 0.4f);
            }
        }
    }

    void CooldownEnd()
    {
        _cooldown = false;
    }
}
