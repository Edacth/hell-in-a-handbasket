using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSensitivity = 1;
    public Transform player;
    public Transform cameraHolderX;
    public Transform cameraHolderY;

    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, -35, 80);

        transform.LookAt(cameraHolderX);

        cameraHolderX.localRotation = Quaternion.Euler(0, mouseX, 0);
        cameraHolderY.localRotation = Quaternion.Euler(mouseY, 0, 0);
    }
}
