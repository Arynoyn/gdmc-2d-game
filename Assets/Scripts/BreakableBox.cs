using DefaultNamespace;
using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.WasPlayer()
            && col.WasBottom())
        {
            Destroy(gameObject);
        }
    }
}
