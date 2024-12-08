using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // ����, ������� ����� ����� �������
    [SerializeField]
    private int damage = 1;
    // ������������ ���������� ���������
    [SerializeField]
    private int maxRicochet = 5;
    // ������� ���������
    private int countRicochet = 0;

    private Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // �������� �� ������������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� ���������� � �������� � ����� "block", �� ������� ���� �����
      
        if (collision.gameObject.GetComponent<Entities>())
        {
            Entities entities = collision.gameObject.GetComponent<Entities>();
            if (entities != null)
            {
                entities.TakeDamage(damage);
            }
        }
        // ���� ����� ������ �� ���, �� ������������
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
        }
        // ������� ���������
        countRicochet++;
        
        // ���� ��������� = ���� ���������, �� ���������� �����
        if (countRicochet == maxRicochet)
        {
            Destroy(gameObject);            
        }
    }
}
