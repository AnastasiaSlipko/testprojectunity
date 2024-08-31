using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� �������� ���������
    private Rigidbody2D rb; // ������ �� ��������� Rigidbody2D
    private Animator animator; // ������ �� ��������� Animator
    private bool facingRight = true; // ���������� ��� ������������ ����������� ���������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �������� ��������� Rigidbody2D
        animator = GetComponent<Animator>(); // �������� ��������� Animator
    }

    void Update()
    {
        // �������� �������������� ����������� (����� ��� ������)
        float moveInput = Input.GetAxis("Horizontal");

        // ������� ���������
        Vector2 movement = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        // ��������� ��������� ��������
        bool isWalking = Mathf.Abs(moveInput) > 0;
        animator.SetBool("isWalking", isWalking);

        // ��������� � ������� ��������� � ����������� �� ����������� ��������
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        // ���������� �������� ����� ��� ������� �������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("attack");
        }
    }

    // ����� ��� ����� ���������
    void Flip()
    {
        facingRight = !facingRight; // ����������� �����������

        // ����������� ������� �� ��� X
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
