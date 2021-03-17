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
    private GameObject enemy;
    private Rigidbody enemyRB;
    public bool firstHit;
    private Object enemyFinder;
    private Object Target;


    // Start is called before the first frame update
    void Start()
    {
        enemyFinder = Resources.Load("Prefabs/EnemyFinder");
        firstHit = false;
        GameObject player = GameObject.Find("PlayerCharacter");        
        chargeCounter = player.GetComponent<SpellCasting>().chargeCounter;
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {       
        enemy = GameObject.Find("EnemyFinder");
        targetFound = enemy.gameObject.GetComponent<CLHIt>();
        Target = targetFound;

        if (firstHit)
        {
            Vector3 Target = (enemyRB.transform.position - transform.position).normalized;
            gameObject.GetComponent<Rigidbody>().AddForce(Target * speed, ForceMode.Impulse);
        }

        Destroy(gameObject, 2.1f);
    }

    private void OnTriggerEnter(Collider other)

    {
        if (!firstHit)
        {
            firstHit = true;
        }
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();
        if(chargeCounter > 1)
        {

            if (enemy != null)
            {
                enemyHealth.AddDamage(_damageAmount);
                chargeCounter--;
                transform.position = Vector3.zero;
                Instantiate(enemyFinder, transform.position, transform.rotation);
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

            if(chargeCounter >= 1)
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
