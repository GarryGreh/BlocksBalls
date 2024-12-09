using UnityEngine;

public class Enemy : Entities
{
    // скорость падения, если нет земли под ногами
    public float fallSpeed = 5f;
    // слой земли, чтобы чекать землю
    public LayerMask ground;
    // расстояние на котором чекать
    public float checkDistance = 0.1f;
    // урон при падении
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
        // пускам луч вниз и проверяем есть ли земля
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, ground);

        if (!isGrounded)
        {            
            // если земли нет, начинаем падение
            rb.velocity = new Vector2(rb.velocity.x, -fallSpeed);
            enemyShot.Fall();
        }
        else
        {
            // если есть земля, можно установить скорость падения в 0
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
        // для визуализации луча в редакторе
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * checkDistance);
    }
}
