using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCharacterController : MonoBehaviour
{
    public Camera cam;
    public Transform playerBody;
    public float gravity = 20;
    public float speed = 10;
    public float jump = 5;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController characterController;
    public bool isGrounded;

    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;
    float rotationLimitPositive = 90f;
    float rotationLimitNegative = -90f;


    // Start is called before the first frame update
    void Start()
    {
        HealthBar.SetHealthBarValue(1);
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //You can modify health with this function
        //HealthBar.SetHealthBarValue(HealthBar.GetHealthBarValue() - 0.01f);
        
        //Used to detect if the character is on the ground
        isGrounded = characterController.isGrounded;

        //Recalculate movement direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //Get input from player
        float curSpeedX = speed * Input.GetAxisRaw("Vertical");
        float curSpeedY = speed * Input.GetAxisRaw("Horizontal");
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        //Jump controls
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        { 
            moveDirection.y = jump;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        //Add gravity when player is in the air
        if (!isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        //Move the player in accordance of player view
        characterController.Move(moveDirection * Time.deltaTime * speed);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, rotationLimitNegative, rotationLimitPositive);
        yRotation -= mouseX;

        cam.transform.eulerAngles = new Vector3(xRotation, -yRotation, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
