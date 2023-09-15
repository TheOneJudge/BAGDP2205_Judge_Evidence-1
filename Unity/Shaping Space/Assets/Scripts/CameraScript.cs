using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    
    [SerializeField] float lookConstraint = 25f;
    [SerializeField] Transform player;

    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float yAxis = Input.GetAxis("Mouse y") * mouseSensitivity * Time.deltaTime;

        xRotation -= yAxis;
        xRotation = Mathf.Clamp(xRotation, -90f, lookConstraint);

        transform.localRotation = quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * xAxis);
    }
}
