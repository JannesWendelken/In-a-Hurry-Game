using UnityEngine;

public class Diamond : MonoBehaviour
{
    public Sprite normal;
    public Sprite outline;
    public AudioClip collectSound; 

    private CashHandler cashHandler;
    private SpriteRenderer spriteRenderer;
    private Vector3 originalScale;

    public int value = 1;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normal;
        originalScale = transform.localScale;
    }

    private void Start()
    {
        cashHandler = CashHandler.FindFirstObjectByType<CashHandler>();
    }

    private void OnMouseEnter()
    {
        spriteRenderer.sprite = outline;
        transform.localScale = originalScale * 1.1f;
    }

    private void OnMouseExit()
    {
        spriteRenderer.sprite = normal;
        transform.localScale = originalScale;
    }

    private void OnMouseDown()
    {
        Collect();
    }

    public void Collect()
    {
        if (cashHandler != null)
            cashHandler.AddCash(value);

        
        if (collectSound != null)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

        Destroy(gameObject);
    }
}
