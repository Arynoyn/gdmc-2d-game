using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput);

        transform.position += movement * (movementSpeed * Time.deltaTime);
    }
}
