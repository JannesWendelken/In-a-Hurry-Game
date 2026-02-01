using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform[] points;
    public float speed = 3f;
    public float rotationSpeed = 360f; 

    private int currentPointIndex = 0;

    void Update()
    {
        if (points.Length == 0) return;

        Transform targetPoint = points[currentPointIndex];

        Vector2 direction = targetPoint.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        float z = transform.position.z;

        Vector3 newPosition = Vector3.MoveTowards(
            transform.position,
            new Vector3(targetPoint.position.x, targetPoint.position.y, z),
            speed * Time.deltaTime
        );

        transform.position = newPosition;

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= points.Length)
                currentPointIndex = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
