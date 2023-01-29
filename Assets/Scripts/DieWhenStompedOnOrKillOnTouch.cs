using DefaultNamespace;
using UnityEngine;

public class DieWhenStompedOnOrKillOnTouch : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawnOnStomp;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.WasHitFromTopSide() 
            && col.WasPlayer())
        {
            if (prefabToSpawnOnStomp != null)
            {
                Instantiate(prefabToSpawnOnStomp, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        } else if (col.WasPlayer())
        {
            GameManager.Instance.KillPlayer();
        }
    }
}
