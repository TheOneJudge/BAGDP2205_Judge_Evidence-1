using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerMove : MonoBehaviour
{
    private CharacterController _controller;
    private float _playerSpeed = 2.0f;
    private Vector2 _playerInput;

    public void playerMove(InputAction.CallbackContext context) 
    {
        _playerInput = context.ReadValue<Vector2>();
    }
    

    // Start is called before the first frame update
    void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(_playerInput.x, 0, _playerInput.y);
        _controller.Move(move * Time.deltaTime * _playerSpeed);
    }
}
