using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Скорость движения персонажа
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Получаем оси движения
        movement.x = Input.GetAxisRaw("Horizontal");

        // Включаем анимацию ходьбы если персонаж движется
        if (movement.x != 0)
        {
            animator.SetBool("isWalking", true);

            // Зеркально отображаем спрайт в зависимости от направления движения
            if (movement.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (movement.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void FixedUpdate()
    {
        // Перемещаем персонажа
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
