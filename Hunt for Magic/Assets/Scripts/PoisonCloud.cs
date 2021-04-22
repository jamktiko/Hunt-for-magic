using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloud : MonoBehaviour
{
    private bool _cooldown;

    private void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            gameObject.transform.localScale += new Vector3(0.03f, 0.015f, 0.045f);
        }
    }

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
