using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    private Rigidbody playerRB;
    private float speed = 5;
    private float jump = 20;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        //make character rigid.
    }

    // Update is called once per frame
    void Update()
    {
        //Key input list
        if (Input.GetKey(KeyCode.A))
            playerRB.AddForce(Vector3.left * speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.D))
            playerRB.AddForce(Vector3.right * speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.W))
            playerRB.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.S))
            playerRB.AddForce(0, 0, -1 * speed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.Space))
            playerRB.AddForce(Vector3.up * jump, ForceMode.Impulse);

    }
}
