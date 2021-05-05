using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilPool : MonoBehaviour
{
    public float duration = 5f;

    void start()
    {
        GameObject _player = GameObject.Find("PlayerCharacter");
        duration = _player.GetComponent<CrystalScript>().duration;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            var enemy = other.gameObject.GetComponent<Rigidbody>();

            if (enemy.tag == "Monster")
            {
                other.gameObject.GetComponent<Debuffs>()._oily = true;
            }
        }

        if (other.GetComponentInParent<Transform>().gameObject.name.Contains("Fire"))
        {
            Destroy(gameObject);
        }
    }
}
