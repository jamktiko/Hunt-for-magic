using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeMovement : MonoBehaviour
{
    private float jump = 25f;
    private float speed = 3;
    private Rigidbody enemyRB;
    private GameObject player;
    public bool touchGround = true;

    // Start is called before the first frame update
    void Start()
    {
        touchGround = false;
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("PlayerCharacter");
        //make slime rigid
    }

    // Update is called once per frame
    void Update()
    {
        if (touchGround)
        {
            enemyRB.AddForce(Vector3.up * jump, ForceMode.Impulse);
            touchGround = false;
        }
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRB.AddForce(lookDirection * speed);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGround = true;
        }
    }
}
