using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject floor1;
    public GameObject floor2;

    private bool floor1Active = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        floor1Active = !floor1Active;

        floor1.SetActive(floor1Active);
        floor2.SetActive(!floor1Active);
    }
}
