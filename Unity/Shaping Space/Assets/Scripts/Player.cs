using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    private Rigidbody _rb;//player not bullet
    private Vector2 _movementInput;
    public GameObject bulletPrefab;//bullet prefab
    public Transform bulletSpawn;//where the bullet spawns

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void onMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
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
        _rb.MovePosition(_rb.position + move * speed * Time.deltaTime);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.velocity = bullet.transform.forward * 10f;

        Destroy(bullet, 3.0f);
    }
}
