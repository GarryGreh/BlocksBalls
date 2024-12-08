using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    // ������ ������
    public GameObject ball;
    // ���������� ��������� �� ���
    [Range(1, 10)]
    public int shootPerTurn = 10;
    // ������� ���������
    private int countShoot = 0;
    // �������� ��������� (�������)
    [SerializeField]
    private float shootInterval = 0.5f;
    // ����� ������ ������ (��������)
    public Transform shootPoint;
    // ��� ������������ ����������� �����
    public Transform gun;

    // ���� �������
    public float launchForce = 500f;

    // ������� ������� ��� ������� ������
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
        // ���� ������ ���, �������� ������� ������� �� ������ � ��������� � ������� ����������
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            launchPos = mousePos;
            
            // �������� ������� ������� �� ������� "�����", ��� ����� ��� ����, ��� "�����" ������� �� ��������
            mousePos -= gun.position;
            // �������� ���� � ������� � ��������� � �������
            float rotZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            // ����������� "�����" � ������� �������
            gun.rotation = Quaternion.Euler(0, 0, rotZ + offset);

            mousePos.z = 0; // �������� Z, ����� ��������� ������� � �������� � 2D
            
        }
        // ���� ��������� ���, �� ��������� ����� � ����������� � ������ Launch()
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

            // �������� Rigidbody ������
            Rigidbody2D rb = ballClone.GetComponent<Rigidbody2D>();

            // ��������� ����������� �� ������� ������ � ������� ����
            Vector2 launchDirection = (launchPos - shootPoint.position).normalized;

            // ��������� ���� � Rigidbody2D
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
