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

    private Object _rocketjumpTrigger;


    // Start is called before the first frame update
    void Start()
    {
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * _speed, ForceMode.Impulse);
        _rocketjumpTrigger = Resources.Load("Prefabs/RocketjumpTrigger");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

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
            if (other.GetComponent<Debuffs>()._wet == true)
            {
                other.GetComponent<Debuffs>()._chilled = true;
            }

            if (other.GetComponent<Debuffs>()._shocked == true)
            {
                other.GetComponent<Debuffs>()._stunned = true;
            }
            enemy.AddForce(0, 3f, 10f, ForceMode.Impulse);
            enemyHealth.AddDamage(_damageAmount);
        }

        if (other.tag == "Ground")
        {
            Object rocketJump = Instantiate(_rocketjumpTrigger, transform.position, Quaternion.identity);
            Destroy(rocketJump, 0.1f);
            
        }
    }
}
