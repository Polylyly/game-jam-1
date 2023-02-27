using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CombatCamera : MonoBehaviour
{
    public float mousSens = 100f;
    public Transform body;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
    }
}
