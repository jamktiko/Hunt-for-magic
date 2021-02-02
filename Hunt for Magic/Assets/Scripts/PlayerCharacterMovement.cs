using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 2;
    public float jump = 5;

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
            playerRB.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            playerRB.transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            playerRB.transform.Translate(transform.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(-playerRB.transform.forward * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
            playerRB.AddForce(transform.up * jump, ForceMode.Impulse);

    }
}
