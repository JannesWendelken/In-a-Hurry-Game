using UnityEngine;

[RequireComponent(typeof(Camera))]
public class AspectRatioLock : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1920, 1200, FullScreenMode.Windowed);
    }
}
