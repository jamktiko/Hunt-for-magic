using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingSpell : MonoBehaviour
{
    [SerializeField]
    private float _baseDamage = 12f;
    public float _damageAmount;
    public float bonus_Damage;
    private bool chargeHold = false;
    private Transform _castingPoint;
    private float speed = 50f;
    private Object _elecHit;
    public GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        _elecHit = Resources.Load("Prefabs/OnHitElec");
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * speed, ForceMode.Impulse);
        _player = GameObject.Find("PlayerCharacter");
        bonus_Damage = _player.GetComponent<CrystalScript>().lightningBonus;
        _damageAmount = _baseDamage + bonus_Damage;
    }

    // Update is called once per frame
    void Update()
    {
        
        spellCharger();
        Destroy(gameObject, 0.7f);
    }

    private void OnTriggerEnter(Collider other)

    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null)
        {
            if (other.GetComponent<Debuffs>()._wet == true)
            {
                _damageAmount *= 1.5f;
            }

            enemyHealth.AddDamage(_damageAmount);
            other.GetComponent<Debuffs>()._shocked = true;

            Object onHitElec = Instantiate(_elecHit, transform.position, Quaternion.identity);
            Destroy(onHitElec, 1f);

            Destroy(gameObject);
        }

        if (other.tag == "Wall")
        {
            Destroy(gameObject.GetComponentInParent<ParticleSystem>());
            Destroy(gameObject);
        }
    }

    private void spellCharger()
    {
        chargeHold = true;
            if (chargeHold)
            {
                Cooldown();
                chargeHold = false;
            }
            else chargeHold = false;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2.4f);
    }
}