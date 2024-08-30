using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // �������� �������� ���������
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 movement;

    void Start()
    {
        // �������� ����������� ����������
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // �������� �������������� ��������
        movement.x = Input.GetAxisRaw("Horizontal");

        // �������� �������� ������ ���� �������� ��������
        if (movement.x != 0)
        {
            animator.SetBool("isWalking", true);

            // �������� � ���������� ���������� ������������ �������
            if (movement.x > 0)
            {
                spriteRenderer.flipX = false; // ����������� ������
            }
            else if (movement.x < 0)
            {
                spriteRenderer.flipX = true; // ����������� �����
            }

            // Debug: ����������� �������� flipX
            Debug.Log("flipX: " + spriteRenderer.flipX);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void FixedUpdate()
    {
        // ���������� ���������
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
