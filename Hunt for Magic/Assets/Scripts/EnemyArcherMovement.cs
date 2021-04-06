using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherMovement : MonoBehaviour
{
    private float speed = 4f;
    private float runSpeed = 6f;
    private float attackDamage = 10f;
    private Rigidbody enemyRB;
    private GameObject player;
    private Transform lookDirectionNode;
    private Transform _arrowStartPoint;
    private bool isChargeAttacking = false;
    public bool isAttacking = false;
    public bool animationReady = false;
    private bool inRange;
    private bool runRange;
    private bool attackRange;
    public bool attackCommence;
    public bool patrol;
    private bool running;
    private bool rollDice;
    private bool looking;
    public bool clHit;
    public bool touchGround = true;
    public bool chargeTrigger = true;
    public float chargeAttackRoller;
    private float LD1;
    private float LD2;
    private float step;
    private float runStep;
    private Object _arrowType;




    // Start is called before the first frame update
    void Start()
    {
        _arrowType = Resources.Load("Prefabs/ArrowHitbox");
        _arrowStartPoint = transform.Find("ArrowSpawnPoint");
        step = speed * Time.deltaTime;
        runStep = runSpeed * Time.deltaTime;
        clHit = false;
        touchGround = false;
        chargeTrigger = false;
        running = false;
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
            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) <= 17 && Vector3.Distance(player.transform.position, enemyRB.transform.position) > 9) // attack range checker
            {
                attackRange = true;
            }
            else attackRange = false;

            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) >= 25) // patrol spotter
            {
                inRange = false;
                attackRange = false;
                runRange = false;
                patrol = true;
            }

            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) <= 5) // run away spotter
            {
                runRange = true;
            }
            else runRange = false;

            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) < 25) // player spotter
            {
                inRange = true;
            }

            if (inRange && !attackRange) // move closer command line
            {
                if(patrol)
                {
                    patrol = false;                  
                }
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            }
            else if (!inRange)
            {
                patrol = true;
            }

            if (!inRange) // patrol command line
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
                        StartCoroutine(PatrolPhaser());
                        lookDirectionNode.localPosition = new Vector3(LD1, 0, LD2);
                        transform.LookAt(lookDirectionNode.transform.position);               
                        
                    }
                    transform.position = Vector3.MoveTowards(transform.position, lookDirectionNode.transform.position, step);
                }
            }
            
            if (inRange && !running)
            {
                transform.LookAt(player.transform.position);
                _arrowStartPoint.localPosition = new Vector3(0f, 0f, 1f);
            }


            if (attackRange)
            {
                if (!isAttacking)
                {
                    isAttacking = true;
                    Instantiate(_arrowType, _arrowStartPoint.position, _arrowStartPoint.rotation);
                    StartCoroutine(AttackCooldown());
                    attackCommence = true;
                }
                else if (attackCommence)
                {

                }
                
            }

            if (runRange) // run away commandline
            {
                if (!running)
                {
                    running = true;
                }            
                if (runRange && running)
                {
                    transform.LookAt(-player.transform.position);
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -1 * runStep);
                }
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
        clHit = true;
        yield return new WaitForSeconds(2.4f);
        clHit = false;
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(2.7f);
        attackCommence = false;
        isAttacking = false;
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
        else if (!collision.gameObject.CompareTag("Ground") || !collision.gameObject.CompareTag("Wood"))
        {
            touchGround = false;
        }


        if (collision.gameObject.name.Contains("ChainLightning"))
        {
            StartCoroutine(CLcooldown());
        }
    }
}
