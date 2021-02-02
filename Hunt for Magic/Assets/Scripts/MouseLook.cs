﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    public Camera cam;

    float xRotation = 0f;
    float yRotation = 0f;
    float rotationLimitPositive = 90f;
    float rotationLimitNegative = -90f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, rotationLimitNegative, rotationLimitPositive);
        yRotation -= mouseX;

        cam.transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
