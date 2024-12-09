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
        
        GameController.Instance.PlayerTurnIsOver += Shoot; // подписка на событие, когда закончилс€ ход игрока
    }

    public void Fall()
    {
        isFalled = true;
    }    
    public void Unsubscribe()
    {
        GameController.Instance.PlayerTurnIsOver -= Shoot; // отписка, перед уничтожением врага
    }
    public void Shoot()
    {
        if (!isFalled)
        {
            player = FindObjectOfType<Player>().transform;
            GameObject ballClone = Instantiate(ball, transform.position, Quaternion.identity);

            // получить Rigidbody шарика
            Rigidbody2D rb = ballClone.GetComponent<Rigidbody2D>();

            // ¬ычисл€ем направление от позиции шарика к позиции мыши
            Vector2 launchDirection = (player.position - transform.position).normalized;

            // ѕримен€ем силу к Rigidbody2D
            rb.AddForce(launchDirection * speed);
        }
        else
        {
            return;
        }
    }
}
