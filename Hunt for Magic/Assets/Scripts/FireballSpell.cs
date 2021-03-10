using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount = 15f;

    private GameObject _explosion;

    private GameObject _groundFire;

    private Transform _castingPoint;

    private float _speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        _explosion = Resources.Load<GameObject>("Prefabs/Explosion");
        _groundFire = Resources.Load<GameObject>("Prefabs/ground_on_fire");

        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * _speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null && enemy.name != "PlayerCharacter")
        {
            enemyHealth.AddDamage(_damageAmount);
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Instantiate(_groundFire, transform.position, Quaternion.Euler(90, 0, 0));
        }

        if (other.gameObject.tag == "Ground")
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Instantiate(_groundFire, transform.position, Quaternion.Euler(90, 0, 0));
        }    
    }
}
