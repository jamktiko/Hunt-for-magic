using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float _explosionDamage = 10f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            other.GetComponent<HealthSystem>().AddDamage(_explosionDamage);
        }
        if (gameObject.tag == "Hazard")
        {
            if (other.tag == "Player")
            {
                other.GetComponent<HealthSystem>().AddDamage(_explosionDamage);
            }
        }
    }
}
