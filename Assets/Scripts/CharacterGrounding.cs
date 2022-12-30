using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    public bool IsGrounded { get; private set; }


    // Update is called once per frame
    private void Update()
    {
        Vector2 leftFootPosition = leftFoot.position;
        Vector2 rightFootPosition = rightFoot.position;
        IsGrounded = CheckGrounding(leftFootPosition) || CheckGrounding(rightFootPosition);
    }

    private bool CheckGrounding(Vector2 leftFootPosition)
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(leftFootPosition, Vector2.down, maxDistance, layerMask);
        Debug.DrawRay(leftFootPosition, Vector2.down * maxDistance, Color.red);
        return raycastHit.collider != null;
    }
}
