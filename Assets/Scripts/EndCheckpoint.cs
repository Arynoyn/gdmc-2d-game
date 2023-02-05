using UnityEngine;
public class EndCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameManager.Instance.MoveToNextLevel();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
    }
}
