using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    public Rigidbody playerRB;
    public Camera cam; 
    public Transform playerBody;
    public float speed = 10;
    public float jump = 5;
    private Vector3 moveInput;

    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;
    float rotationLimitPositive = 90f;
    float rotationLimitNegative = -90f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerRB = GetComponent<Rigidbody>();
        //make character rigid.
    }

    // Update is called once per frame
    void Update()
    {
        //Get input from player
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Move the player in accordance of player view
        playerRB.transform.Translate(moveInput * Time.deltaTime * speed);
        
        if (Input.GetKeyDown(KeyCode.Space))
        { playerRB.AddForce(transform.up * jump, ForceMode.Impulse); }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, rotationLimitNegative, rotationLimitPositive);
        yRotation -= mouseX;

        cam.transform.eulerAngles = new Vector3(xRotation, -yRotation, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
