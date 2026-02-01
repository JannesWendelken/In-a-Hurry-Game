using UnityEngine;
using TMPro;

public class FloorUI : MonoBehaviour
{
    public TMP_Text text;
    public int startFloor = 1;

    public GameObject[] floors;

    private void Update()
    {
        for (int i = 0; i < floors.Length; i++)
        {
            if (floors[i] != null && floors[i].activeSelf)
            {
                text.text = "Floor: " + (startFloor + i);
                return;
            }
        }
    }
}
