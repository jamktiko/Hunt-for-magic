using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeMovement : MonoBehaviour
{
    private float jump = 3;
    public float speed = 3;
    private float attackDamage = 5f;
    private Rigidbody enemyRB;
    private Transform lookDirectionNode;
    private bool inRange;
    private float LD1;
    private float LD2;
    private GameObject player;
    private GameObject _hud;
    public bool touchGround = true;
    public bool attackTrigger1 = true;
    public bool attackTrigger2 = true;
    public bool chargeTrigger = true;
    public float chargeAttackRoller;
    public bool isChargeAttacking = false;
    public bool animationReady = false;
    public bool clHit;
    public AudioSource _slimeSounds;
    public AudioClip _slimeJump;
    public AudioClip _slimeAoe;
    public float _maxRange = 25f;
    public float _range;
    public bool _inFog;
    private bool CLcooldownActive;

    // Start is called before the first frame update
    void Start()
    {
        clHit = false;
        touchGround = false;
        attackTrigger2 = false;
        attackTrigger1 = false;
        chargeTrigger = false;
        enemyRB = GetComponent<Rigidbody>(); // make slime rigid
        player = GameObject.Find("PlayerCharacter"); // find player character
        lookDirectionNode = transform.Find("LookDirectionNode");
        transform.LookAt(lookDirectionNode.transform.position);
        _slimeSounds = GetComponent<AudioSource>();
        _range = 25f;
        _hud = GameObject.Find("HUD");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (_inFog || _hud.GetComponentInChildren<PlayerDebuffs>()._inFog)
        {
            _range = 5f;
        }
        else
        {
            _range = _maxRange;
        }

        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, enemyRB.transform.position) < _range)
            {
                inRange = true;
            }
            else inRange = false;

            if (clHit && !CLcooldownActive)
            {
                CLcooldownActive = true;
                StartCoroutine(CLcooldown());
            }
        }

        if (chargeTrigger && !isChargeAttacking)
        {
            isChargeAttacking = true;
            StartCoroutine(chargeTimer());
        }

        else
        {

            if (touchGround && !inRange) //jump command
            {
                StartCoroutine(jumpPhaser());
                if (lookDirectionNode != null)
                {
                    transform.LookAt(lookDirectionNode.transform.position);
                }
                Vector3 lookDirection = (lookDirectionNode.transform.position - transform.position).normalized; // patrol movement
                enemyRB.AddForce(Vector3.up * jump, ForceMode.Impulse); // upward motion command
                enemyRB.AddForce(lookDirection * speed, ForceMode.Impulse); // forward motion command
                touchGround = false;
                attackTrigger1 = false;
                attackTrigger2 = false;
                LD1 = Random.Range(-1f, 1f);
                LD2 = Random.Range(-1f, 1f);
                lookDirectionNode.transform.localPosition = new Vector3(LD1,0,LD2);
                if (!_slimeSounds.isPlaying)
                {
                    _slimeSounds.PlayOneShot(_slimeJump);
                }
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
                if (!_slimeSounds.isPlaying)
                {
                    _slimeSounds.PlayOneShot(_slimeJump);
                }
            }

            if (attackTrigger2) //attack trigger
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
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wood"))
        {
            touchGround = true; //jump checker
            attackTrigger1 = true; // splash checker
            chargeAttackRoller = Random.Range(0, 11); // charge attact randomizer

            if (chargeAttackRoller <= 9 || !inRange)
            {

            }
            else if (chargeAttackRoller == 10 && inRange && collision.gameObject.CompareTag("Ground"))
            {
                attackTrigger1 = false;
                attackTrigger2 = false;
                chargeTrigger = true;
            }
        }

        if (collision.gameObject.CompareTag("Player") && GetComponent<HealthSystem>()._deadSlime == false)
        {
            attackTrigger2 = true; // impact checker
            var enemyHealth = collision.gameObject.GetComponent<HealthSystem>();
            enemyHealth.AddDamage(attackDamage);
            {
                _slimeSounds.PlayOneShot(_slimeJump);
            }
        }

        if (collision.gameObject.CompareTag("ChainLightning"))
        {
            clHit = true;
            StartCoroutine(CLcooldown());
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            enemyRB.velocity = Vector3.zero;
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRB.AddForce(Vector3.up * 2f, ForceMode.Impulse);
            enemyRB.AddForce(-lookDirection * 1.2f, ForceMode.Impulse);
        }
    }

    IEnumerator chargeTimer()
    {
        enemyRB.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.8f);
        gameObject.GetComponentInChildren<SlimeAnimation>()._chargeAttack = true;
        if (!_slimeSounds.isPlaying)
        {
            _slimeSounds.PlayOneShot(_slimeAoe);
        }
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

    IEnumerator CLcooldown()
    {
        yield return new WaitForSeconds(2.6f);
        clHit = false;
        CLcooldownActive = false;
    }
}
