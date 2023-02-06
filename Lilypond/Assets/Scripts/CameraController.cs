using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float clampAngle = 80f;
    [SerializeField] float cameraClampAngle = 3.0f;
    [SerializeField] Transform cameraTransform;
    float rotX = 0.0f;
    float rotY = 0.0f;
    float camRotX = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = -Input.GetAxis("Mouse Y");

        rotX += y * mouseSensitivity * Time.deltaTime;
        rotY += x * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        //camRotX = Mathf.Clamp(rotX, -cameraClampAngle, cameraClampAngle);
        camRotX = (rotX/cameraClampAngle) + 5;

        transform.rotation = Quaternion.Euler(rotX, rotY, 0.0f);
        cameraTransform.rotation = Quaternion.Euler(camRotX, rotY, 0.0f);
    }
}
