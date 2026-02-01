using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform target; 

    void Update()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
}
