using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    private TextMeshProUGUI tmproText { get; set; }

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmproText.text = GameManager.Instance.Lives.ToString();
    }
}
