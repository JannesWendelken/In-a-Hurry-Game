using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    public TMP_Text highscoreText; // Assign your TMP text in the Inspector
    public GameObject player;

    private CashHandler cashHandler;

    private void Start()
    {
        if (player != null)
        {
            cashHandler = player.GetComponent<CashHandler>();
            if (cashHandler == null)
                Debug.LogWarning("CashHandler not found on the player!");
        }
        else
        {
            Debug.LogWarning("Player GameObject not assigned!");
        }
    }

    private void Update()
    {
        if (cashHandler != null)
        {
            highscoreText.text = "Highscore: $" + cashHandler.Cash.ToString("N0");
        }
    }
}
