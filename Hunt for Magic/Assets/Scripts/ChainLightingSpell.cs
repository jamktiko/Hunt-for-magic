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
    private Rigidbody enemyRB;
    public bool firstHit;
    public Object enemyFinder;
    public GameObject target;
    private Rigidbody thisRB;


    // Start is called before the first frame update
    void Start()
    {
        targetFound = false;
        enemyFinder = Resources.Load("Prefabs/EnemyFinder");
        firstHit = false;
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
            spellCharger();
        }

        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("Monster"))
        {
            var enemy = other.gameObject.GetComponent<Rigidbody>();

            var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

            if (!firstHit && enemy != null)
            {
                firstHit = true;
            }

            if (chargeCounter > 0 && enemy != null)
            {
                thisRB.velocity = Vector3.zero;

                Instantiate(enemyFinder, thisRB.transform.position, thisRB.transform.rotation);

                enemyHealth.AddDamage(_damageAmount);

                chargeCounter--;
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

            if(chargeCounter == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void spellCharger()
    {
        var enemyFinUpdate = GameObject.Find("EnemyFinder");

        if (enemyFinUpdate != null)
        {
            target = enemyFinUpdate.GetComponent<CLHIt>().Target;

            Vector3 Target = (target.transform.position - transform.position).normalized;
            thisRB.AddForce(Target * speed, ForceMode.Impulse);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2f);
    }

}
