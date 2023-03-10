using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UILivesText : MonoBehaviour
{
    private TextMeshProUGUI _tmproText;

    private void Awake()
    {
        _tmproText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnLivesChanged += HandleOnLivesChanged;
    }

    private void HandleOnLivesChanged(int livesRemaining) { 
        _tmproText.text = livesRemaining.ToString();
     }
}
