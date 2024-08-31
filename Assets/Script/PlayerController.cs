using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа
    private Rigidbody2D rb; // Ссылка на компонент Rigidbody2D
    private Animator animator; // Ссылка на компонент Animator
    private bool facingRight = true; // Переменная для отслеживания направления персонажа

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
        animator = GetComponent<Animator>(); // Получаем компонент Animator
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
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        // Активируем анимацию атаки при нажатии пробела
        if (Input.GetKeyDown(KeyCode.Space))
        {
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
}
