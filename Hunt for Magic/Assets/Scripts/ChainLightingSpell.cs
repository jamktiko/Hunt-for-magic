using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightingSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount = 30f;
    private Transform _castingPoint;
    private float speed = 20f;
    public float chargeCounter;
    public bool targetFound;
    public Rigidbody enemyRB;
    public bool firstHit;
    public Object enemyFinder;
    public Transform target;
    public GameObject enemyFinUpdate;
    private Rigidbody thisRB;
    private Object _elecHit;


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
    }

    // Update is called once per frame
    void FixedUpdate()
    {      
        if (firstHit)
        {
            if (enemyFinUpdate.name.Contains("Fin"))
            {
                Vector3 Target = (target.transform.position - transform.position).normalized;
                thisRB.AddForce(Target * speed, ForceMode.Impulse);
            }
        }

        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("Monster"))
        {
            other.gameObject.GetComponent<EnemySlimeMovement>().clHit = true;
           
            var enemy = other.gameObject.GetComponent<Rigidbody>();

            var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

            if (!firstHit)
            {
                Instantiate(enemyFinder, thisRB.transform.position, thisRB.transform.rotation);
                enemyFinUpdate = GameObject.Find("EnemyFinder");
                firstHit = true;
            }

            if (chargeCounter > 0 && enemy.CompareTag("Monster"))
            {
                thisRB.velocity = Vector3.zero;

                chargeCounter--;

                if (other.GetComponent<Debuffs>()._wet == true)
                {
                    _damageAmount *= 1.5f;
                }

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
