using UnityEngine;
using TMPro;
using System.Collections;

public class CashHandler : MonoBehaviour
{
    [SerializeField] private int cash = 0;
    public int Cash => cash;

    public TMP_Text cashUI;
    private Coroutine updateCoroutine;

    private void Start()
    {
        cash = 0;

        if (cashUI != null)
            cashUI.text = "$" + cash.ToString("N0");
    }

    public void AddCash(int amount)
    {
        cash += amount;
        if (updateCoroutine != null) StopCoroutine(updateCoroutine);
        updateCoroutine = StartCoroutine(UpdateCashUISmooth());
    }

    private IEnumerator UpdateCashUISmooth()
    {
        float displayedCash;
        if (!float.TryParse(cashUI.text.Replace("$","").Replace(",",""), out displayedCash))
            displayedCash = 0;

        float speed = 5f;

        while ((int)displayedCash != cash)
        {
            displayedCash = Mathf.Lerp(displayedCash, cash, Time.deltaTime * speed);

            if (Mathf.Abs(cash - displayedCash) < 0.5f)
                displayedCash = cash;

            cashUI.text = "$" + ((int)displayedCash).ToString("N0");
            yield return null;
        }
    }
}
