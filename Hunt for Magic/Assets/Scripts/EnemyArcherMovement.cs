using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherMovement : MonoBehaviour
{
    private float speed = 4f;
    private float runSpeed = 6f;
    private float attackDamage = 10f;
    private Rigidbody enemyRB;
    private Transform lookDirectionNode;
    private bool inRange;
    private bool runRange;
    private bool attackRange;
    private GameObject player;
    public bool touchGround = true;
    public bool chargeTrigger = true;
    public float chargeAttackRoller;
    public bool isChargeAttacking = false;
    public bool animationReady = false;
    private float LD1;
    private float LD2;
    public bool clHit;
    private bool clWait;
    private Vector3 lookDirection;
    private bool patrol;
    private float step;
    private float runStep;
    private bool runAway;
    private bool running;
    private bool rollDice;
    private bool looking;

    // Start is called before the first frame update
    void Start()
    {
        step = speed * Time.deltaTime;
        runStep = runSpeed * Time.deltaTime;
        clHit = false;
        touchGround = false;
        chargeTrigger = false;
        running = false;
        runAway = false;
        enemyRB = GetComponent<Rigidbody>(); // make Archer rigid
        player = GameObject.Find("PlayerCharacter"); // find player character
        lookDirectionNode = transform.Find("LookDirectionNode");
        transform.LookAt(lookDirectionNode.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) <= 15 && Vector3.Distance(player.transform.position, enemyRB.transform.position) > 10)
            {
                attackRange = true;
            }
            else attackRange = false;

            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) >= 25)
            {
                inRange = false;
                attackRange = false;
                runRange = false;
            }
            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) <= 10)
            {
                runRange = true;
            }
            else runRange = false;

            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) < 25)
            {
                inRange = true;
            }

            if (inRange && !attackRange)
            {
                if(patrol)
                {
                    patrol = false;                  
                }
                transform.LookAt(player.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            }
            else if (!inRange)
            {
                patrol = true;
            }

            if (!inRange)
            {
                if (!patrol)
                {
                    patrol = true;                  
                }

                if (patrol)
                {                            
                    if (!looking)
                    {
                        looking = true;
                        LD1 = Random.Range(-1f, 1f);
                        LD2 = Random.Range(-1f, 1f);
                        transform.LookAt(lookDirectionNode.transform.position);
                        lookDirectionNode.transform.localPosition = new Vector3(LD1, 0, LD2);
                        PatrolPhaser();
                    }
                    transform.position = Vector3.MoveTowards(transform.position, lookDirectionNode.transform.position, step);
                }
            }
            else if (inRange)
            {
                patrol = false;
            }

            if (attackRange)
            {
                //attack comes here
            }

            if (runRange)
            {
                if (!running)
                {
                    running = true;
                }
                runAway = true;
                patrol = false;             
                if (runAway && running)
                {
                    transform.LookAt(-player.transform.position);
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -1 * runStep);
                }
                runAway = false;
            }
            else if (!runRange)
            {
                running = false;
            }

            if(attackRange && chargeTrigger)
            {
                //special attack comes here
            }
        }
    }
    IEnumerator PatrolPhaser()
    {
        yield return new WaitForSeconds(3f);
        looking = false;
    }

    IEnumerator CLcooldown()
    {
        clWait = true;
        yield return new WaitForSeconds(2.6f);
        clWait = false;
        clHit = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGround = true; //movement checker
            chargeAttackRoller = Random.Range(0, 16); // charge attact randomizer

            if (chargeAttackRoller <= 9 || !inRange)
            {

            }
            else if (chargeAttackRoller == 15 && inRange)
            {

                chargeTrigger = true;
            }
        }
        else if (!collision.gameObject.CompareTag("Ground"))
        {
            touchGround = false;
        }


        if (collision.gameObject.name.Contains("ChainLightning"))
        {
            clHit = collision.gameObject.GetComponent<ChainLightingSpell>().targetFound;
            CLcooldown();
        }
    }
}
