using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform[] touchPoints;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    
    public bool IsGrounded { get; private set; }

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition;
    
    // Update is called once per frame
    private void Update()
    {
        foreach (Transform touchPoint in touchPoints)
        {
            IsGrounded = CheckGrounding(touchPoint.position);
            if (IsGrounded) { break; }

        }

        StickToGroundedObject();
    }

    private void StickToGroundedObject()
    {
        if (groundedObject != null)
        {
            if (groundedObjectLastPosition.HasValue 
                && groundedObjectLastPosition.Value != groundedObject.position)
            {
                Vector3 delta = groundedObject.position - groundedObjectLastPosition.Value;
                transform.position += delta;
            }

            groundedObjectLastPosition = groundedObject.position;
        }
        else
        {
            groundedObjectLastPosition = null;
        }
    }

    private bool CheckGrounding(Vector2 touchpoint)
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(touchpoint, Vector2.down, maxDistance, layerMask);
        Debug.DrawRay(touchpoint, Vector2.down * maxDistance, Color.red);

        var groundedObjectExists = raycastHit.collider != null;

        if (groundedObjectExists)
        {
            if (groundedObject != raycastHit.collider.transform)
            {
                groundedObject = raycastHit.collider.transform;
                groundedObjectLastPosition = groundedObject.position;
            }
        }
        else
        {
            groundedObject = null;
        }

        return groundedObjectExists;
    }
}
