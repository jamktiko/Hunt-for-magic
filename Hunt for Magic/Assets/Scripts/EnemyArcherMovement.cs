﻿using System.Collections;
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
    public bool inRange;
    private bool runRange;
    public bool attackRange;
    public bool strafe;
    public bool attackCommence;
    public bool patrol;
    public bool running;
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
    private bool CLcooldownActive;
    public Object _arrowType;
    public float ATRoll;

    // Start is called before the first frame update
    void Start()
    {      
        step = speed * Time.deltaTime;
        runStep = runSpeed * Time.deltaTime;
        clHit = false;
        touchGround = false;
        chargeTrigger = false;
        running = false;
        enemyRB = GetComponent<Rigidbody>(); // make Archer rigid
        player = GameObject.Find("PlayerCharacter"); // find player character
        _arrowStartPoint = transform.Find("ArrowSpawnPoint");
        lookDirectionNode = transform.Find("LookDirectionNode");
        transform.LookAt(lookDirectionNode.transform.position);

        if(_arrowType == null)
        {
            ATRoll = Random.Range(1, 6);
            if(ATRoll == 1)
            {
                _arrowType = Resources.Load("Prefabs/FireArrow");
            }
            else if (ATRoll == 2)
            {
                _arrowType = Resources.Load("Prefabs/ThunderArrow");
            }
            else if (ATRoll == 3)
            {
                _arrowType = Resources.Load("Prefabs/WaterArrow");
            }
            else if (ATRoll == 4)
            {
                _arrowType = Resources.Load("Prefabs/WindArrow");
            }
            else if (ATRoll == 5)
            {
                _arrowType = Resources.Load("Prefabs/IceArrow");
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            if (clHit && !CLcooldownActive)
            {
                CLcooldownActive = true;
                StartCoroutine(CLcooldown());
            }

            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) <= 17 && Vector3.Distance(player.transform.position, enemyRB.transform.position) > 6) // attack range checker
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

            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) <= 6) // run away spotter
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
                    }
                    transform.LookAt(lookDirectionNode.transform.position);
                    transform.position = Vector3.MoveTowards(transform.position, lookDirectionNode.transform.position, step);
                }
            }
            
            if (inRange && !running)
            {
                if (!strafe && !running)
                {
                    transform.LookAt(player.transform.position);
                }

                _arrowStartPoint.localPosition = new Vector3(0f, 0f, 1f);
                _arrowStartPoint.LookAt(player.transform.position);
            }


            if (attackRange)
            {
                if (!isAttacking && !attackCommence)
                {
                    StartCoroutine(AttackTrigger());

                    Instantiate(_arrowType, _arrowStartPoint.position, _arrowStartPoint.rotation);

                    attackCommence = true;

                    StartCoroutine(AttackCooldown());                 
                }
                else if (attackCommence)
                {
                    float LD3 = Random.Range(1,3);
                    if (!strafe)
                    {
                        strafe = true;
                        StartCoroutine(StrafePhaser());
                        if (LD3 == 1)
                        {
                            lookDirectionNode.localPosition = new Vector3(2, 0, 0);
                        }
                        if (LD3 == 2)
                        {
                            lookDirectionNode.localPosition = new Vector3(-2, 0, 0);
                        }
                        transform.LookAt(lookDirectionNode.transform.position);
                        lookDirectionNode.localPosition = new Vector3(0, 0, 1);
                    }
                    else if (strafe)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, lookDirectionNode.transform.position, step);
                    }
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
                    lookDirectionNode.localPosition = new Vector3(0, 0, -1);
                    transform.LookAt(lookDirectionNode.transform.position);
                    lookDirectionNode.localPosition = new Vector3(0, 0, 1);
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -1 * runStep);
                }
            }
            else if (!runRange)
            {
                running = false;
            }

            if(chargeTrigger)
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

    IEnumerator StrafePhaser()
    {
        yield return new WaitForSeconds(1.5f);
        strafe = false;
        attackCommence = false;
    }

    IEnumerator CLcooldown()
    {
        clHit = true;
        yield return new WaitForSeconds(2.4f);
        clHit = false;
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(4.2f);       
        isAttacking = false;
    }

    IEnumerator AttackTrigger()
    {
        yield return new WaitForSeconds(0.1f);
        isAttacking = true;
    }

    void OnCollisionStay(Collision collision)
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
    }
}
