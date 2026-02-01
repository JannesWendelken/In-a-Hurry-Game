using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float sneakMultiplier = 0.5f;
    public float runMultiplier = 2f;
    public float rotationSpeed = 200f;

    public float maxStamina = 5f;
    public float stamina;
    public float staminaDrainRate = 1f;
    public float staminaRegenRate = 0.5f;

    private Rigidbody2D rb2d;
    public Animator animator;
    private float targetRotation;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        targetRotation = rb2d.rotation;
        stamina = maxStamina;
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxisRaw("Vertical");
        float currentSpeed = speed;

        animator.SetBool("isMoving", moveVertical != 0);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            currentSpeed *= sneakMultiplier;

        if (Input.GetKey(KeyCode.Space) && stamina > 0f)
        {
            currentSpeed *= runMultiplier;
            stamina -= staminaDrainRate * Time.fixedDeltaTime;
            stamina = Mathf.Max(stamina, 0f);
        }
        else
        {
            stamina += staminaRegenRate * Time.fixedDeltaTime;
            stamina = Mathf.Min(stamina, maxStamina);
        }

        Vector2 movement = transform.up * moveVertical * currentSpeed * Time.fixedDeltaTime;
        rb2d.MovePosition(rb2d.position + movement);

        if (Input.GetKey(KeyCode.A))
            targetRotation += rotationSpeed * Time.fixedDeltaTime;
        else if (Input.GetKey(KeyCode.D))
            targetRotation -= rotationSpeed * Time.fixedDeltaTime;

        float angle = Mathf.MoveTowardsAngle(rb2d.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        rb2d.MoveRotation(angle);
    }
}
