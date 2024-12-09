using UnityEngine;

public class Enemy : Entities
{
    // �������� �������, ���� ��� ����� ��� ������
    public float fallSpeed = 5f;
    // ���� �����, ����� ������ �����
    public LayerMask ground;
    // ���������� �� ������� ������
    public float checkDistance = 0.1f;
    // ���� ��� �������
    public int fallDamage = 2;

    private Rigidbody2D rb;
    private EnemyShot enemyShot;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public override void Start()
    {
        enemyShot = GetComponent<EnemyShot>();
    }
    private void Update()
    {
        CheckGround();
    }
    private void CheckGround()
    {
        // ������ ��� ���� � ��������� ���� �� �����
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, ground);

        if (!isGrounded)
        {            
            // ���� ����� ���, �������� �������
            rb.velocity = new Vector2(rb.velocity.x, -fallSpeed);
            enemyShot.Fall();
        }
        else
        {
            // ���� ���� �����, ����� ���������� �������� ������� � 0
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            GameObject.FindObjectOfType<Player>().TakeDamage(fallDamage);
            GetComponent<EnemyShot>().Unsubscribe();
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        // ��� ������������ ���� � ���������
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * checkDistance);
    }
}
