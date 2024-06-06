using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Karakterin hareket hızı
    private Rigidbody2D rb; // Karakterin Rigidbody2D bileşeni
    private Vector2 movement; // Hareket vektörü
    public TextMeshProUGUI playerScoreText;
    private bool isFacingRight = true; // Karakterin şu an hangi yöne baktığını tutar
    public int score;
    void Start()
    {
        // Rigidbody2D bileşenini al
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }

    void Update()
    {
        playerScoreText.text = score.ToString();
        // W, A, S, D tuşlarıyla girdi alma
        movement.x = Input.GetAxisRaw("Horizontal"); // A ve D tuşları
        movement.y = Input.GetAxisRaw("Vertical");   // W ve S tuşları

        // Karakterin yönünü değiştirme
        if (movement.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && isFacingRight)
        {
            Flip();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    void FixedUpdate()
    {
        // Hareketi gerçekleştirme
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        // Karakterin yönünü değiştirme
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
