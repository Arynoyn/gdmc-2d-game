using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameManager.Instance.AddCoin();
        Destroy(gameObject);
    }
}
