using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UICoinsText : MonoBehaviour
{
    private TextMeshProUGUI _tmproText;

    private void Awake()
    {
        _tmproText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += HandleCoinsChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= HandleCoinsChanged;
    }

    private void HandleCoinsChanged(int coins)
    {
        _tmproText.text = coins.ToString();
    }
}
