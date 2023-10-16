using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class Player : MonoBehaviour
{
    //Player Movement
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    private Rigidbody _rb;//player not bullet
    private Vector2 _movementInput;

    //Bullet Stuff!
    public GameObject Bullet;//bullet prefab
    public Transform bulletSpawn;//where the bullet spawns

    //Object Pooling
    public int poolsize = 20;
    private List<GameObject> objectPool;

    //Player Rotation
    public Transform playerCamera;  
    public float sensitivity = 0.5f;
    public float maxYAngle = 80.0f;

    private float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        objectPool = new List<GameObject>();

        for(int i = 0; i < poolsize; i++)
        {
            GameObject obj = Instantiate(Bullet);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public void onMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    public void onLook(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        float mouseX = lookInput.x * sensitivity;
        float mouseY = lookInput.y * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);

        playerCamera.transform.Rotate(Vector3.up * mouseX);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        
        transform.Rotate(Vector3.up * mouseX);
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void onShoot(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Shoot();
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(_movementInput.x, 0, _movementInput.y);
        _rb.MovePosition(_rb.position + transform.TransformDirection(move) * speed * Time.deltaTime);
    }

    public GameObject GetBullet()
    {
        for(int i = 0; i < objectPool.Count; i++)
        {
            if(!objectPool[i].activeInHierarchy)
            {
                objectPool[i].SetActive(true);
                return objectPool[i];
            }
        }

        return null;
    }

    void Shoot()
    {
        GameObject bullet = GetBullet();
        if(bullet != null)
        {
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = bulletSpawn.rotation;
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.velocity = bullet.transform.forward * 80f;

            StartCoroutine(ReturnBulletToPool(bullet));
        }
        
    }

    IEnumerator ReturnBulletToPool(GameObject bullet)
    {
        yield return new WaitForSeconds(3);

        if(bullet != null)
        {
            bullet.SetActive(false);
        }
    }
}
