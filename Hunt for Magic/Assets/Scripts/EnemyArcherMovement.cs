using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherMovement : MonoBehaviour
{
    public float speed = 4f;
    private float runSpeed = 6f;
    private float attackDamage = 15f;
    private Rigidbody enemyRB;
    private GameObject lookDirectionNode;
    private bool inRange;
    private bool runRange;
    private bool attackRange;
    private GameObject player;
    public bool touchGround = true;
    public bool attackTrigger1 = true;
    public bool attackTrigger2 = true;
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

    // Start is called before the first frame update
    void Start()
    {
        clHit = false;
        touchGround = false;
        attackTrigger2 = false;
        attackTrigger1 = false;
        chargeTrigger = false;
        enemyRB = GetComponent<Rigidbody>(); // make Archer rigid
        player = GameObject.Find("PlayerCharacter"); // find player character
        lookDirectionNode = GameObject.Find("LookDirectionNode");
        transform.LookAt(lookDirectionNode.transform.position);
    }

    // Update is called once per frame
    void Update()
    {        
        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) <= 15)
            {
                inRange = true;
                attackRange = true;
                runRange = false;
            }
            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) >= 25)
            {
                inRange = false;
                attackRange = false;
                runRange = false;
            }
            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) <= 10)
            {
                inRange = true;
                attackRange = false;
                runRange = true;
            }
            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) < 25)
            {
                inRange = true;
                attackRange = false;
                runRange = false;
            }

            if (inRange && !attackRange)
            {
                if(patrol)
                {
                    patrol = false;
                }

            }

            if (!inRange)
            {
                PatrolPhaser();
                enemyRB.AddForce(lookDirection * speed, ForceMode.Impulse);
            }

            if (attackRange && !runRange)
            {
                //attack comes here
            }

            if (runRange)
            {
                //runaway comes here
            }
        }
    }
    IEnumerator PatrolPhaser()
    {
        patrol = true;
        if (lookDirectionNode != null)
        {
            transform.LookAt(lookDirectionNode.transform.position);
        }
        yield return new WaitForSeconds(3f);
        LD1 = Random.Range(-1f, 1f);
        LD2 = Random.Range(-1f, 1f);
        lookDirectionNode.transform.localPosition = new Vector3(LD1, 0, LD2);
        lookDirection = (lookDirectionNode.transform.position - transform.position).normalized; // patrol movement
        patrol = false;
    }
}
