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
    private Object targetFound;
    private Rigidbody enemyRB;
    public bool firstHit;
    private Object enemyFinder;
    private Rigidbody target;
    private Rigidbody thisRB;


    // Start is called before the first frame update
    void Start()
    {
        enemyFinder = Resources.Load("Prefabs/EnemyFinder");
        firstHit = false;
        GameObject player = GameObject.Find("PlayerCharacter");        
        chargeCounter = player.GetComponent<SpellCasting>().spellCharge;
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * speed, ForceMode.Impulse);
        thisRB = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {      
        if (firstHit)
        {
            var enemy = GameObject.Find("EnemyFinder");
            target = enemy.gameObject.GetComponent<CLHIt>().Target;
            enemyRB = target;

            Vector3 Target = (enemyRB.transform.position - thisRB.transform.position).normalized;
            thisRB.AddForce(Target * speed, ForceMode.Impulse);
        }

        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)

    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (!firstHit && enemy != null)
        {
            firstHit = true;
        }
        
        if(chargeCounter > 0)
        {

            if (enemy != null)
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
        
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2f);
    }

}
