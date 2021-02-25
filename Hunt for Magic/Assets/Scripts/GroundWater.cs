using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundWater : MonoBehaviour
{
    [SerializeField]
    private bool _electric;

    // Start is called before the first frame update
    void Start()
    {
        _electric = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        if (enemy != null && enemy.name != "PlayerCharacter")
        {
            if (other.name == "LightningSpellCollider")
            {
                _electric = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        if (enemy != null && enemy.name != "PlayerCharacter")
        {
            other.gameObject.GetComponent<Debuffs>()._wet = true;

            if (_electric == true)
            {
                enemy.GetComponent<HealthSystem>().AddDamage(0.01f);
            }
        }
    }
}