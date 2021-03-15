using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeMovement : MonoBehaviour
{
    private float jump = 3;
    public float speed = 3;
    private float attackDamage = 5f;
    private Rigidbody enemyRB;
    private GameObject lookDirectionNode;
    private bool inRange;
    private float LD1;
    private float LD2;
    private GameObject player;
    public bool touchGround = true;
    public bool attackTrigger1 = true;
    public bool attackTrigger2 = true;
    public bool chargeTrigger = true;
    public float chargeAttackRoller;
    public bool isChargeAttacking = false;
    public bool animationReady = false;

    // Start is called before the first frame update
    void Start()
    {
        touchGround = false;
        attackTrigger2 = false;
        attackTrigger1 = false;
        chargeTrigger = false;
        enemyRB = GetComponent<Rigidbody>(); // make slime rigid
        player = GameObject.Find("PlayerCharacter"); // find player character
        lookDirectionNode = GameObject.Find("LookDirectionNode");
        transform.LookAt(lookDirectionNode.transform.position);


    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) < 15)
            {
                inRange = true;
            }
            else inRange = false;
        }

        if (chargeTrigger)
        {
            isChargeAttacking = true;
            StartCoroutine(chargeTimer());
        }
        else
        {

            if (touchGround && !inRange) //jump command
            {
                StartCoroutine(jumpPhaser());
                transform.LookAt(lookDirectionNode.transform.position);
                Vector3 lookDirection = (lookDirectionNode.transform.position - transform.position).normalized; // patrol movement
                enemyRB.AddForce(Vector3.up * jump, ForceMode.Impulse); // upward motion command
                enemyRB.AddForce(lookDirection * speed, ForceMode.Impulse); // forward motion command
                touchGround = false;
                attackTrigger1 = false;
                attackTrigger2 = false;
                LD1 = Random.Range(-1f, 1f);
                LD2 = Random.Range(-1f, 1f);
                lookDirectionNode.transform.localPosition = new Vector3(LD1,0,LD2);
                
            }
            else if (inRange && touchGround) //chase command
            {
                StartCoroutine(jumpPhaser());
                Vector3 lookDirection = (player.transform.position - transform.position).normalized; // search for player
                enemyRB.AddForce(Vector3.up * jump, ForceMode.Impulse); // upward motion command
                enemyRB.AddForce(lookDirection * speed, ForceMode.Impulse); // forward motion command
                touchGround = false;
                attackTrigger1 = false;
                attackTrigger2 = false;
            }

            if (attackTrigger2)
            {
                enemyRB.velocity = Vector3.zero;
                Vector3 lookDirection = (player.transform.position - transform.position).normalized; // search for player
                enemyRB.AddForce(Vector3.up * jump, ForceMode.Impulse); // upward motion command
                enemyRB.AddForce(-lookDirection * speed, ForceMode.Impulse); // forward motion command
                attackTrigger2 = false;
                attackTrigger1 = false;
                touchGround = false;
            }
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGround = true; //jump checker
            attackTrigger1 = true; // splash checker
            chargeAttackRoller = Random.Range(0, 11); // charge attact randomizer

            if (chargeAttackRoller <= 9 || !inRange)
            {

            }
            else if (chargeAttackRoller == 10 && inRange)
            {
                attackTrigger1 = false;
                attackTrigger2 = false;
                chargeTrigger = true;
                gameObject.GetComponentInChildren<SlimeAnimation>()._chargeAttack = true;
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            attackTrigger2 = true; // impact checker
            var enemyHealth = collision.gameObject.GetComponent<HealthSystem>();
            enemyHealth.AddDamage(attackDamage);
        }
    }

    IEnumerator chargeTimer()
    {
        enemyRB.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.8f);
        animationReady = true;
        yield return new WaitForSeconds(1.2f);
        chargeTrigger = false;
        isChargeAttacking = false;
        animationReady = false;
    }

    IEnumerator jumpPhaser()
    {
        enemyRB.velocity = Vector3.zero;
        yield return new WaitForSeconds(1f);
    }
}
