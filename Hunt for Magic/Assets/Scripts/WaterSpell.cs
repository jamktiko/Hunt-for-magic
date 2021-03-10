using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount = 8f;
    private float _speed = 5f;

    private Transform _waterCastingPoint;
    private Vector3 scaleChange, positionChange;

    private Object _waterPool;


    void Start()
    {
        _waterCastingPoint = GameObject.Find("WaterCastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_waterCastingPoint.forward * _speed, ForceMode.Impulse);
        gameObject.GetComponent<SphereCollider>();
        scaleChange = new Vector3(0.003f, -0.0008f, 0);
        positionChange = new Vector3(0, -0.0001f, 0);
        StartCoroutine("DamageFizzle");
        _waterPool = Resources.Load("Prefabs/GroundWater");
    }

    // Update is called once per frame
    void Update()
    {
        Object.Destroy(gameObject, 5.0f);
        
        gameObject.transform.localScale += scaleChange;
        gameObject.transform.position += positionChange;
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
        if (other.gameObject.tag != "Player")
        {
            var enemy = other.gameObject.GetComponent<Rigidbody>();

            var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

            if (enemy != null && enemy.tag == "Monster")
            {
                enemyHealth.AddDamage(_damageAmount);
                other.gameObject.GetComponent<Debuffs>()._wet = true;

                Object groundWater = Instantiate(_waterPool, transform.TransformPoint(0, -1.28f, 0), Quaternion.identity);
                Destroy(groundWater, 5f);
            }
        }
    }

    IEnumerator DamageFizzle()
    {
        yield return new WaitForSeconds(0.1f);
        if (_damageAmount > 0)
        {
            _damageAmount -= 0.3f;
        }
    }
}
