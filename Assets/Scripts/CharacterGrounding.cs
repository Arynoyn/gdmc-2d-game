using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    
    public bool IsGrounded { get; private set; }

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition;
    
    // Update is called once per frame
    private void Update()
    {
        Vector2 leftFootPosition = leftFoot.position;
        Vector2 rightFootPosition = rightFoot.position;
        IsGrounded = CheckGrounding(leftFootPosition) || CheckGrounding(rightFootPosition);
        
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

    private bool CheckGrounding(Vector2 footPosition)
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(footPosition, Vector2.down, maxDistance, layerMask);
        Debug.DrawRay(footPosition, Vector2.down * maxDistance, Color.red);

        var groundedObjectExists = raycastHit.collider != null;
        
        groundedObject = groundedObjectExists 
            ? raycastHit.collider.transform 
            : null;

        return groundedObjectExists;
    }
}
