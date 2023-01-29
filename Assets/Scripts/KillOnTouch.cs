using DefaultNamespace;
using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.WasPlayer())
        {
            GameManager.Instance.KillPlayer();
        }
    }
}