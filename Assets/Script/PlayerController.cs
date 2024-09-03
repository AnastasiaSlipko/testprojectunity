using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа
    private Rigidbody2D rb; // Ссылка на компонент Rigidbody2D
    private Animator animator; // Ссылка на компонент Animator
    private bool facingRight = true; // Переменная для отслеживания направления персонажа

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D не найден на объекте");
        }

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator не найден на объекте");
        }

        // Отключаем root motion
        animator.applyRootMotion = false;
    }

    void Update()
    {
        // Получаем горизонтальное направление (влево или вправо)
        float moveInput = Input.GetAxis("Horizontal");

        // Двигаем персонажа
        Vector2 movement = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        // Обновляем состояние анимации
        bool isWalking = Mathf.Abs(moveInput) > 0;
        animator.SetBool("isWalking", isWalking);

        // Проверяем и флипаем персонажа в зависимости от направления движения
        if (moveInput < 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput > 0 && facingRight)
        {
            Flip();
        }

        // Активируем анимацию атаки при нажатии пробела
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Приостанавливаем движение во время атаки
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetTrigger("attack");
        }
    }

    // Метод для флипа персонажа
    void Flip()
    {
        facingRight = !facingRight; // Переключаем направление

        // Инвертируем масштаб по оси X
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnAnimatorMove()
    {
        // Игнорируем изменения позиции анимацией
    }
}
