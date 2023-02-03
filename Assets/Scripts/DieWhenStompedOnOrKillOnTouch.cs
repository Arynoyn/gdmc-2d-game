using DefaultNamespace;
using UnityEngine;

public class DieWhenStompedOnOrKillOnTouch : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawnOnStomp;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.WasPlayer())
        {
            if (col.WasTop())
            {
                if (prefabToSpawnOnStomp != null)
                {
                    Instantiate(prefabToSpawnOnStomp, transform.position, transform.rotation);
                }
                Destroy(gameObject);
            } else
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }
}
