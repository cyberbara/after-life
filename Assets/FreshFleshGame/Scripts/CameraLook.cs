using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform PlayerBody;
    public static float mousesentifity = 200;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesentifity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesentifity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }

    public void Sensity()
    {
        mousesentifity = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), mousesentifity, 0.0f, 10.0f);
    }
}
