using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool Activated { get; private set; }

    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerMovementController player = col.GetComponent<PlayerMovementController>();
        if (player != null)
        {
            Activated = true;
        }
    }
}
