using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform[] touchPoints;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    
    public bool IsGrounded { get; private set; }
    public Vector2? GroundedDirection { get; private set; }

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition;
    
    // Update is called once per frame
    private void Update()
    {
        foreach (Transform touchPoint in touchPoints)
        {
            IsGrounded = CheckGrounding(touchPoint);
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

    private bool CheckGrounding(Transform touchpoint)
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(touchpoint.position, touchpoint.forward, maxDistance, layerMask);
        Debug.DrawRay(touchpoint.position, touchpoint.forward * maxDistance, Color.red);

        var groundedObjectExists = raycastHit.collider != null;

        if (groundedObjectExists)
        {
            if (groundedObject != raycastHit.collider.transform)
            {
                groundedObject = raycastHit.collider.transform;
                groundedObjectLastPosition = groundedObject.position;
                GroundedDirection = touchpoint.forward;
            }
        }
        else
        {
            groundedObject = null;
            GroundedDirection = null;
        }

        return groundedObjectExists;
    }
}
