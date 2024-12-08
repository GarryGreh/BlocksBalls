using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // урон, который шарик может нанести
    [SerializeField]
    private int damage = 1;
    // максимальное количество рикошетов
    [SerializeField]
    private int maxRicochet = 5;
    // счётчик рикошетов
    private int countRicochet = 0;

    private Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // проверка на столкновения
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // если столкнулся с объектом с тегом "block", то наносит урон блоку
      
        if (collision.gameObject.GetComponent<Entities>())
        {
            Entities entities = collision.gameObject.GetComponent<Entities>();
            if (entities != null)
            {
                entities.TakeDamage(damage);
            }
        }
        // если шарик падает на пол, то уничтожается
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
        }
        // счётчик рикошетов
        countRicochet++;
        
        // если рикошетов = макс количство, то уничтожаем шарик
        if (countRicochet == maxRicochet)
        {
            Destroy(gameObject);            
        }
    }
}
