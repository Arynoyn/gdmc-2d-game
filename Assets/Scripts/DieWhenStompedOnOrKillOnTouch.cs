using DefaultNamespace;
using UnityEngine;

public class DieWhenStompedOnOrKillOnTouch : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawnOnStomp;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.WasPlayer())
        {
            PlayerMovementController playerController = col.collider.GetComponent<PlayerMovementController>();
            if (col.WasTop())
            {
                if (prefabToSpawnOnStomp != null)
                {
                    Instantiate(prefabToSpawnOnStomp, transform.position, transform.rotation);
                }

                playerController.Bounce();
                
                Destroy(gameObject);
            } else
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }
}
