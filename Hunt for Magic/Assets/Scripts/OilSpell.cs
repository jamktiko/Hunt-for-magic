using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSpell : MonoBehaviour
{
    [SerializeField]
    private float _damage = 5f;
    public float oilBonus = 0f;

    [SerializeField]
    private float _speed = 40f;

    private Transform _castingPoint;
    private GameObject _oilPool;
    private GameObject _oilHit;

    // Start is called before the first frame update
    void Start()
    {
        GameObject _player = GameObject.Find("PlayerCharacter");
        oilBonus = _player.GetComponent<CrystalScript>().oilBonus; ;
        _oilPool = Resources.Load<GameObject>("Prefabs/OilPool");
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * _speed, ForceMode.Impulse);
        _oilHit = Resources.Load<GameObject>("Prefabs/OnHitOil");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(GetComponentInParent<Transform>().gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.gameObject.GetComponent<Rigidbody>();

        if (enemy != null && enemy.tag == "Monster" || collision.gameObject.tag == "Ground")
        {
            Destroy(GetComponentInParent<Transform>().gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var _addDamage = _damage + oilBonus;

        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null && enemy.tag == "Monster")
        {
            enemyHealth.AddDamage(_addDamage);
            other.gameObject.GetComponent<Debuffs>()._oily = true;

            if (!enemy.gameObject.name.Contains("Plantie"))
            {
                Instantiate(_oilPool, new Vector3(other.transform.position.x, 0.01f, other.transform.position.z), Quaternion.Euler(0, 0, 0));
            }

            GameObject onHitOil = Instantiate(_oilHit, transform.position, Quaternion.identity);
            Destroy(onHitOil, 1f);

            Destroy(GetComponentInParent<Transform>().gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            Instantiate(_oilPool, new Vector3(transform.position.x, 0.01f, transform.position.z), Quaternion.Euler(0, 0, 0));
            Destroy(GetComponentInParent<Transform>().gameObject);
        }

        if (other.CompareTag("Wall") || other.name.Contains("Barrel"))
        {
            Destroy(GetComponentInParent<Transform>().gameObject);
        }
    }
}
