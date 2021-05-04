using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightingSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;
    private Transform _castingPoint;
    private float speed = 20f;
    public float chargeCounter;
    public bool targetFound;
    public Rigidbody enemyRB;
    public bool firstHit;
    public Object enemyFinder;
    public Transform target;
    public GameObject CL;
    private Rigidbody thisRB;
    private Object _elecHit;

    private GameObject _barrelExplosion;
    private GameObject _groundFire;


    // Start is called before the first frame update
    void Start()
    {
        targetFound = false;
        enemyFinder = Resources.Load("Prefabs/EnemyFinder");
        firstHit = false;
        _elecHit = Resources.Load("Prefabs/OnHitElec");
        GameObject player = GameObject.Find("PlayerCharacter");        
        chargeCounter = player.GetComponent<SpellCasting>().spellCharge;
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * speed, ForceMode.Impulse);
        thisRB = GetComponent<Rigidbody>();
        _barrelExplosion = Resources.Load<GameObject>("Prefabs/BarrelExplosion");
        _groundFire = Resources.Load<GameObject>("Prefabs/ground_on_fire");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (firstHit)
        {
            if (!targetFound)
            {
                if (target != null)
                {
                    targetFound = true;
                }
            }
            else if (targetFound)
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed);
            }
        }

        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.name.Contains("Barrel"))
        {
            Instantiate(_barrelExplosion, other.transform.position, Quaternion.identity);
            Instantiate(_groundFire, other.transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Monster"))
        {
            if (other.gameObject.name.Contains("Slime"))
            {
                other.gameObject.GetComponent<EnemySlimeMovement>().clHit = true;
            }
            else if (other.gameObject.name.Contains("Archer"))
            {
                other.gameObject.GetComponent<EnemyArcherMovement>().clHit = true;
            }
            else if (other.gameObject.name.Contains("Plantie"))
            {
                other.gameObject.GetComponent<EnemyPlantieMovement>().clHit = true;
            }
           
            var enemy = other.gameObject.GetComponent<Rigidbody>();

            var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

            if (!firstHit)
            {
                firstHit = true;
                                           
            }

            if (chargeCounter > 0 && enemy.CompareTag("Monster"))
            {
                thisRB.velocity = Vector3.zero;

                Instantiate(enemyFinder, thisRB.transform.position, thisRB.transform.rotation);

                chargeCounter--;

                if (other.GetComponent<Debuffs>()._wet == true)
                {
                    _damageAmount *= 1.5f;
                }

                targetFound = false;
                enemyHealth.AddDamage(_damageAmount);
                other.GetComponent<Debuffs>()._shocked = true;

                Object onHitElec = Instantiate(_elecHit, transform.position, Quaternion.identity);
                Destroy(onHitElec, 1f);
            }
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Transform>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy.tag == "Monster")
        {
            enemyHealth.AddDamage(_damageAmount);

            if(chargeCounter < 1)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2f);
    }

}
