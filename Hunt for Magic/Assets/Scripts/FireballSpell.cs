using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : MonoBehaviour
{
    [SerializeField]
    public float _damageAmount;
    private float _baseDamage = 5f;
    private float FireBonus;

    private GameObject _explosion;
    public GameObject _player;
    private GameObject _groundFire;

    private Transform _castingPoint;

    [SerializeField]
    private float _speed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        FireBonus = _player.GetComponent<CrystalScript>().fireBonus;
        _damageAmount = _baseDamage + FireBonus;
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

        if (enemy != null && enemy.tag == "Monster")
        {
            enemyHealth.AddDamage(_damageAmount);
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
            if (!enemy.gameObject.name.Contains("Plantie"))
            {
                Instantiate(_groundFire, transform.position, Quaternion.Euler(90, 0, 0));
            }
        }

        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Wood")
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Instantiate(_groundFire, transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(transform.parent.gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
    }
}
