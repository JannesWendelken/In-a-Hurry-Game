using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public float size = 0.3f;
    public Color color = Color.green;

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, size);
    }
}
