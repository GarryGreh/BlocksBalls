using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject ball;
    public float speed;

    private Transform player;    
    private bool isFalled;

    private void Start()
    {
        isFalled = false;       
        
        GameController.Instance.PlayerTurnIsOver += Shoot; // �������� �� �������, ����� ���������� ��� ������
    }

    public void Fall()
    {
        isFalled = true;
    }    
    public void Unsubscribe()
    {
        GameController.Instance.PlayerTurnIsOver -= Shoot; // �������, ����� ������������ �����
    }
    public void Shoot()
    {
        if (!isFalled)
        {
            player = FindObjectOfType<Player>().transform;
            GameObject ballClone = Instantiate(ball, transform.position, Quaternion.identity);

            // �������� Rigidbody ������
            Rigidbody2D rb = ballClone.GetComponent<Rigidbody2D>();

            // ��������� ����������� �� ������� ������ � ������� ����
            Vector2 launchDirection = (player.position - transform.position).normalized;

            // ��������� ���� � Rigidbody2D
            rb.AddForce(launchDirection * speed);
        }
        else
        {
            return;
        }
    }
}
