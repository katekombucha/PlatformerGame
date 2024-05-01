using System;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Публічна змінна для налаштування сили стрибка в інспекторі Unity.
    public float jumpForce = 300;
    private bool inAir = false;
    
    // Приватна змінна для зберігання компонента Rigidbody2D, який управляє фізикою двовимірного об'єкта.
    private Rigidbody2D rigidbody2D;

    // Метод Start викликається перед першим кадром
    void Start()
    {
        // Отримання компонента Rigidbody2D, прикріпленого до цього GameObject
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Метод Update викликається один раз на кадр
    void Update()
    {
        // Перевіряємо, чи натиснута клавіша пробіл
        if (!inAir && Input.GetKeyDown(KeyCode.Space))
        {
            // Застосовуємо силу вгору для створення стрибка
            // Vector2(0, jumpForce) означає силу, спрямовану вертикально вгору без горизонтального переміщення
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
            inAir = true;
        }

        if (inAir)
        {
            Vector3 vel = rigidbody2D.velocity;
            vel.y -= 4 * Time.deltaTime;
            rigidbody2D.velocity = vel;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Platform>() != null)
        {
            inAir = false;
        }
    }
}