using System;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Публічна змінна для налаштування сили стрибка в інспекторі Unity.
    public float jumpForce = 150;

    public LayerMask groundLayer;
    // Приватна змінна для зберігання компонента Rigidbody2D, який управляє фізикою двовимірного об'єкта.
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider;

    // Метод Start викликається перед першим кадром
    void Start()
    {
        // Отримання компонента Rigidbody2D, прикріпленого до цього GameObject
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Метод Update викликається один раз на кадр
    void Update()
    {
        // Перевіряємо, чи натиснута клавіша пробіл
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
           
            // Застосовуємо силу вгору для створення стрибка
            // Vector2(0, jumpForce) означає силу, спрямовану вертикально вгору без горизонтального переміщення
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }

        if (!IsGrounded())
        {
            Vector3 vel = rigidbody2D.velocity;
            vel.y -= 3 * Time.deltaTime;
            rigidbody2D.velocity = vel;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D =
            Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down * 0.2f, 0.1f, groundLayer);
        return raycastHit2D.collider != null;
    }
}