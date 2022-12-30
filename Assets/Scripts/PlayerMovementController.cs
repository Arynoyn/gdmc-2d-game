using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float jumpForce = 400;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        Vector3 movement = new Vector3(horizontalInput, 0);

        transform.position += movement * (movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
