using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpell : MonoBehaviour  //Tämä scripti liitetään WindEffect-prefabin SphereCollideriin
{
    [SerializeField]
    private float _damageAmount = 5f;

    [SerializeField]
    private float _speed = 10f;

    private Transform _castingPoint;


    // Start is called before the first frame update
    void Start()
    {
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

        if (enemy != null)
        {
            enemy.AddForce(0, 3f, 10f, ForceMode.Impulse);
            enemyHealth.AddDamage(_damageAmount);
        }
    }
}
