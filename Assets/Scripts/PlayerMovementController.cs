using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterGrounding))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float jumpForce = 400;

    public float Speed { get; private set; }

    private Rigidbody2D _rigidbody2D;
    private CharacterGrounding _characterGrounding;

    private void Awake()
    {
        _characterGrounding = GetComponent<CharacterGrounding>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && _characterGrounding.IsGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
    
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Speed = horizontalInput;
        Vector3 movement = new Vector3(horizontalInput, 0);

        transform.position += movement * (movementSpeed * Time.deltaTime);
    }
}
