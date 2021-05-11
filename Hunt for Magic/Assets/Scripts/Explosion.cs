using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float _explosionDamage = 10f;
    private float _addDamage;
    private float _firebonus;

    public GameObject _player;


    private void OnTriggerEnter(Collider other)
    {
        _player = GameObject.Find("PlayerCharacter");
        _firebonus = _player.GetComponent<CrystalScript>().fireBonus;
        _addDamage = _firebonus + _explosionDamage;

        if (other.tag == "Monster")
        {
            other.GetComponent<HealthSystem>().AddDamage(_addDamage);
        }
        if (gameObject.tag == "Hazard")
        {
            if (other.tag == "Player")
            {
                other.GetComponent<HealthSystem>().AddDamage(_addDamage);
            }
        }
    }
}
