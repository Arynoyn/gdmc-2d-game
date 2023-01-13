using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        bool wasHitFromBelow = col.contacts[0].normal.y > 0;
        bool isPlayer = col.collider.GetComponent<PlayerMovementController>() != null;

        if (isPlayer
            && wasHitFromBelow)
        {
            Destroy(gameObject);
        }
    }
}
