using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    // префаб шарика
    public GameObject ball;
    // количество выстрелов за ход
    [Range(1, 10)]
    public int shootPerTurn = 10;
    // счЄтчик выстрелов
    private int countShoot = 0;
    // интервал выстрелов (очередь)
    [SerializeField]
    private float shootInterval = 0.5f;
    // точка спавна шарика (выстрела)
    public Transform shootPoint;
    // дл€ визуализации направлени€ пушки
    public Transform gun;

    // сила запуска
    public float launchForce = 500f;

    // позици€ курсора дл€ запуска шарика
    private Vector3 launchPos;

    private GameManager gameManager;
    private Player player;

    private float offset = -90;

    private void Start()
    {
        if (gameManager == null)
        gameManager = FindObjectOfType<GameManager>();

        if(player == null) 
            player = GetComponent<Player>();
    }

    private void Update()
    {
        // если нажата Ћ ћ, получаем позицию курсора на экране и переводим в мировые координаты
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            launchPos = mousePos;
            
            // отнимаем позицию курсора от позиции "пушки", это нужно дл€ того, что "пушка" следила за курсором
            mousePos -= gun.position;
            // получаем угол в радиаах и переводим в градусы
            float rotZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            // поворачивем "пушку" в сторону курсора
            gun.rotation = Quaternion.Euler(0, 0, rotZ + offset);

            mousePos.z = 0; // обнул€ем Z, чтобы исключить глубину и работать в 2D
            
        }
        // если отпустить Ћ ћ, то спавнитс€ шарик и запускаетс€ в методе Launch()
        if(Input.GetMouseButtonUp(0))
        {
            StartCoroutine(Launch());
        }
    }
    //private void Launch()
    private IEnumerator Launch()
    {        
        for (int i = 0; i < shootPerTurn; i++)
        {            
            GameObject ballClone = Instantiate(ball, shootPoint.position, Quaternion.identity);

            // получить Rigidbody шарика
            Rigidbody2D rb = ballClone.GetComponent<Rigidbody2D>();

            // ¬ычисл€ем направление от позиции шарика к позиции мыши
            Vector2 launchDirection = (launchPos - shootPoint.position).normalized;

            // ѕримен€ем силу к Rigidbody2D
            rb.AddForce(launchDirection * launchForce);

            countShoot++;
            if (countShoot >= shootPerTurn)
            {
                gameManager.TheMoveEnded();
                player.ChangePosition();
                countShoot = 0;
            }
            yield return new WaitForSeconds(shootInterval);
        }
    }
}
