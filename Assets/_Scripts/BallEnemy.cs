using UnityEngine;

public class BallEnemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
        }
    }
}
