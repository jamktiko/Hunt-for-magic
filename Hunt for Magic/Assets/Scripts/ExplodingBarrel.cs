using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
    private GameObject _barrelExplosion;
    private GameObject _groundFire;

    private void Start()
    {
        _barrelExplosion = Resources.Load<GameObject>("Prefabs/BarrelExplosion");
        _groundFire = Resources.Load<GameObject>("Prefabs/ground_on_fire");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent.tag == "Spell")
        {
            Instantiate(_barrelExplosion, transform.position, Quaternion.identity);
            Instantiate(_groundFire, transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(gameObject);
        }
    }
}
