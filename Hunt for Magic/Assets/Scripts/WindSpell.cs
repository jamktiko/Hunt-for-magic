using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpell : MonoBehaviour  //Tämä scripti liitetään WindEffect-prefabin SphereCollideriin
{
    [SerializeField]
    public float _damageAmount;
    private float _baseDamage = 15f;

    [SerializeField]
    private float _speed = 10f;
    private float _AirBonus;

    private Transform _castingPoint;

    [SerializeField]
    private Object _rocketjumpTrigger;
    public GameObject _player;

    private Vector3 _forward;

    private Object _windHit;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _AirBonus = _player.GetComponent<CrystalScript>().airBonus;
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * _speed, ForceMode.Impulse);
        _forward = new Vector3(_castingPoint.forward.x, 0.1f, _castingPoint.forward.z);
        _damageAmount = _AirBonus + _baseDamage;
        _windHit = Resources.Load("Prefabs/OnHitwind");
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
            enemyHealth.AddDamage(_damageAmount);

            if (other.GetComponent<Debuffs>()._wet == true)
            {
                other.GetComponent<Debuffs>()._chilled = true;
            }

            if (other.GetComponent<Debuffs>()._shocked == true)
            {
                other.GetComponent<Debuffs>()._stunned = true;
            }

            enemy.AddForce(_forward * (20f - Vector3.Distance(enemy.position, _castingPoint.position)), ForceMode.Impulse);

            Object onHitwind = Instantiate(_windHit, transform.position, Quaternion.identity);
            Destroy(onHitwind, 1f);
        }

        if (other.tag == "Ground" || other.tag == "Wood")
        {
            Object rocketJump = Instantiate(_rocketjumpTrigger, transform.position, Quaternion.identity);
            Destroy(rocketJump, 0.02f);
            
        }

        if (other.tag == "Wall" || other.name.Contains("Barrel"))
        {
            Destroy(gameObject.GetComponentInParent<ParticleSystem>());
            Destroy(gameObject);
        }
    }
}
