using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcewallSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount = 20f;

    [SerializeField]
    private float _speed = 35f;

    private Transform _castingPoint;

    private Transform _waterCastingPoint;

    private Object _iceWall;

    // Start is called before the first frame update
    void Start()
    {
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        _waterCastingPoint = GameObject.Find("WaterCastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * _speed, ForceMode.Impulse);
        _iceWall = Resources.Load("Prefabs/IcyWall");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null && enemy.tag == "Monster")
        {
            enemyHealth.AddDamage(_damageAmount);

            Object icewall = Instantiate(_iceWall, transform.position, _waterCastingPoint.rotation);
            Destroy(icewall, 8f);

            Destroy(gameObject);
        }
        else if (other.tag == "Ground" || other.tag == "Wood")
        {
            Object icewall = Instantiate(_iceWall, transform.position, _waterCastingPoint.rotation);
            Destroy(icewall, 8f);

            Destroy(gameObject);
        }
    }
}
