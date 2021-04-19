using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBoltSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;
    private float _damageBoost;
    private Transform _castingPoint;
    private float speed = 20f;
    public float chargeCounter;
    public float _boostAmount;
    private Object onHitElec;
    private Object _elecHit;


    // Start is called before the first frame update
    void Start()
    {
        _elecHit = Resources.Load("Prefabs/OnHitElec");
        GameObject player = GameObject.Find("PlayerCharacter"); //Find player
        chargeCounter = player.GetComponent<SpellCasting>().spellCharge; //get amount of charges
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * speed, ForceMode.Impulse);
        _boostAmount = player.GetComponent<CrystalScript>().lightningBonus;
    }

    // Update is called once per frame
    void Update()
    {
        
        Destroy(gameObject, 2.1f);
    }

    private void OnTriggerEnter(Collider other)

    {
        _damageBoost = _boostAmount * chargeCounter;
        _damageAmount = 25 + _damageBoost;

        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();
        if (chargeCounter > 1)
        {

            if (enemy != null && enemy.tag == "Monster")
            {
                enemyHealth.AddDamage(_damageAmount);
                chargeCounter--;
                onHitElec = Instantiate(_elecHit, transform.position, Quaternion.identity);
                Destroy(onHitElec, 1f);
            }

            if (other.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null)
        {
            enemyHealth.AddDamage(_damageAmount);

            if (chargeCounter <= 1)
            {
                Destroy(gameObject);
            }
        }

        if (other.tag == "Wall")
        {
            Destroy(gameObject.GetComponentInParent<ParticleSystem>());
            Destroy(gameObject);
        }
    }

    private void spellCharger()
    {

    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2f);
    }

}