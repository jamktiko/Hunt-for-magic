using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSpell : MonoBehaviour
{
    [SerializeField]
    private float _damage = 5f;

    [SerializeField]
    private float _speed = 10f;

    private Transform _castingPoint;
    private GameObject _oilPool;

    // Start is called before the first frame update
    void Start()
    {
        _oilPool = Resources.Load<GameObject>("Prefabs/OilPool");
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * _speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.gameObject.GetComponent<Rigidbody>();

        if (enemy != null && enemy.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null && enemy.tag == "Monster")
        {
            enemyHealth.AddDamage(_damage);
            other.gameObject.GetComponent<Debuffs>()._oily = true;

            if (!enemy.gameObject.name.Contains("Plantie"))
            {
                Instantiate(_oilPool, new Vector3(other.transform.position.x, 0f, other.transform.position.z), Quaternion.Euler(0, 0, 0));
            }

            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            Instantiate(_oilPool, new Vector3(transform.position.x, 0f, transform.position.z), Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }

        if (other.CompareTag("Wall") || other.name.Contains("Barrel"))
        {
            Destroy(gameObject);
        }
    }
}
