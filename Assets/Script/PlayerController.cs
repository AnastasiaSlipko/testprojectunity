using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;  // Скорость движения персонажа

    void Update()
    {
        // Проверяем нажатие клавиши "влево"
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        // Проверяем нажатие клавиши "вправо"
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
