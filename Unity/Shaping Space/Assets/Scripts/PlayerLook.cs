using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    
    public GameObject player;
    Vector2 lookMovement;
    float xMove,yMove;
    float camerOffset;
    [SerializeField] float mouseSensitivity = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        camerOffset = transform.position.y - player.transform.position.y;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = player.transform.position;
        position.y += camerOffset;
        transform.position = position;
        lookMovement = Mouse.current.delta.ReadValue();
        xMove += -lookMovement.y * Time.deltaTime * mouseSensitivity;
        xMove = Mathf.Clamp(xMove, -90, 90);
        yMove += -lookMovement.x * Time.deltaTime * mouseSensitivity;
        transform.rotation = Quaternion.Euler(xMove,yMove,0);
        
    }
}
