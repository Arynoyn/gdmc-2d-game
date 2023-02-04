using DefaultNamespace;
using Interfaces;
using UnityEngine;

public class BreakableBox : MonoBehaviour, ITakeShellHit
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.WasPlayer()
            && col.WasBottom())
        {
            Destroy(gameObject);
        }
    }

    public void HandleShellHit(ShellFlipped shellFlipped)
    {
        Destroy(gameObject);
    }
}
