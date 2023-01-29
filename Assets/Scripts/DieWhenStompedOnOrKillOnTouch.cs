using DefaultNamespace;
using UnityEngine;

public class DieWhenStompedOnOrKillOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.WasHitFromTopSide() 
            && col.WasPlayer())
        {
            Destroy(gameObject);
        } else if (col.WasPlayer())
        {
            GameManager.Instance.KillPlayer();
        }
    }
}
