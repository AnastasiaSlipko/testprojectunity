using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;  // �������� �������� ���������

    void Update()
    {
        // ��������� ������� ������� "�����"
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        // ��������� ������� ������� "������"
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
