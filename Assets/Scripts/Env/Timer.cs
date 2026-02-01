using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time = 60f;
    public TMP_Text timerText;

    private bool loaded = false;

    private void Update()
    {
        if (loaded) return;

        if (time > 0f)
        {
            time -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            loaded = true;
            time = 0f;
            UpdateTimerUI();
            SceneManager.LoadScene("Success");
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int seconds = Mathf.CeilToInt(time);
            timerText.text = seconds + "s";
        }
    }
}
