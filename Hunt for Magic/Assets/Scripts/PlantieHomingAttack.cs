using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantieHomingAttack : MonoBehaviour
{
    private GameObject _player;
    private Transform _target;
    private float _addDamage = 7f;
    private float _speed = 0.5f;
    private float _weight;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _target = _player.GetComponent<Transform>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var enemyHealth = other.gameObject.GetComponent<HealthSystem>();
            enemyHealth.AddDamage(_addDamage);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wood"))
        {
            Destroy(gameObject);
        }
        else
        {

        }
    }
}
