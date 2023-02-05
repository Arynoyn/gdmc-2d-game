using UnityEngine;
public class EndCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameManager.Instance.MoveToNextLevel();
    }
}
