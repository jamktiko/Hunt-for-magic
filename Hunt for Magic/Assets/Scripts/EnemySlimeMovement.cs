using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeMovement : MonoBehaviour
{
    private float jump = 3;
    private float speed = 3;
    private float attackDamage = 5;
    private Rigidbody enemyRB;
    private GameObject player;
    public bool touchGround = true;
    public bool attackTrigger1 = true;
    public bool attackTrigger2 = true;
    public bool chargeTrigger = true;
    public float chargeAttackRoller;

    // Start is called before the first frame update
    void Start()
    {
        touchGround = false;
        attackTrigger2 = false;
        attackTrigger1 = false;
        chargeTrigger = false;
        enemyRB = GetComponent<Rigidbody>(); // make slime rigid
        player = GameObject.Find("PlayerCharacter"); // find player character
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chargeTrigger)
        {
            StartCoroutine(chargeTimer());
        }
        else
        {
            
            if (touchGround) //jump command
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

            if (chargeAttackRoller <= 9)
            {

            }
            else
            {
                attackTrigger1 = false;
                attackTrigger2 = false;
                chargeTrigger = true;

            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            attackTrigger2 = true; // impact checker
        }
    }

    IEnumerator chargeTimer()
    {
        enemyRB.velocity = Vector3.zero;
        yield return new WaitForSeconds(2);
        chargeTrigger = false;
    }

    IEnumerator jumpPhaser()
    {
        enemyRB.velocity = Vector3.zero;
        yield return new WaitForSeconds(1);
    }
}
