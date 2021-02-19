using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount = 15f;
    private float _speed = 5f;

    private Transform _waterCastingPoint;
    private Vector3 scaleChange, positionChange;


    void Start()
    {
        _waterCastingPoint = GameObject.Find("WaterCastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_waterCastingPoint.forward * _speed, ForceMode.Impulse);
        gameObject.GetComponent<SphereCollider>();
        scaleChange = new Vector3(0.003f, -0.0008f, 0);
        positionChange = new Vector3(0, -0.0001f, 0);
        StartCoroutine("DamageFizzle");
    }

    // Update is called once per frame
    void Update()
    {
        Object.Destroy(gameObject, 5.0f);
        
        gameObject.transform.localScale += scaleChange;
        gameObject.transform.position += positionChange;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            var enemy = other.gameObject.GetComponent<Rigidbody>();

            var enemyHealth = other.gameObject.GetComponent<HealthSystem>();
            if (enemy != null)
            {
                enemyHealth.AddDamage(_damageAmount);
                other.GetComponent<WetDebuff>()._wet = true;
            }
        }
    }

    IEnumerator DamageFizzle()
    {
        yield return new WaitForSeconds(0.1f);
        if (_damageAmount > 0)
        {
            _damageAmount -= 0.1f;
        }
    }
}
