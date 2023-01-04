using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        PlayerMovementController playerMovementController = col.collider.GetComponent<PlayerMovementController>();
        if (playerMovementController != null)
        {
            GameManager.Instance.KillPlayer();
        }
    }
}