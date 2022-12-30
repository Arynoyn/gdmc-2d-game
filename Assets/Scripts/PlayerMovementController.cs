using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float jumpForce = 400;

    private Rigidbody2D _rigidbody2D;
    private CharacterGrounding _characterGrounding;

    private void Awake()
    {
        _characterGrounding = GetComponent<CharacterGrounding>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        Vector3 movement = new Vector3(horizontalInput, 0);

        transform.position += movement * (movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1") && _characterGrounding.IsGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
