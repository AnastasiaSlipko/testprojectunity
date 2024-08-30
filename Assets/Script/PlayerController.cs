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
        // Получаем необходимые компоненты
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Получаем горизонтальное движение
        movement.x = Input.GetAxisRaw("Horizontal");

        // Включаем анимацию ходьбы если персонаж движется
        if (movement.x != 0)
        {
            animator.SetBool("isWalking", true);

            // Проверка и управление зеркальным отображением спрайта
            if (movement.x > 0)
            {
                spriteRenderer.flipX = false; // Направление вправо
            }
            else if (movement.x < 0)
            {
                spriteRenderer.flipX = true; // Направление влево
            }

            // Debug: Отслеживаем значение flipX
            Debug.Log("flipX: " + spriteRenderer.flipX);
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
