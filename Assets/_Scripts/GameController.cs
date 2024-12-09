using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public event Action PlayerTurnIsOver;

    private int countBalls = 0;
    private int maxBalls;

    private void Awake()
    {
        Instance = this;
    }
    
    // �������� ���������� �������, ������� ����� ����� ��������� �� ���
    public void GetNumberBalls(int number)
    {
        maxBalls = number;
    }
    // ���������� ����� ������������ ������, ������������� ���������� �������
    public void BallCounter()
    {
        countBalls++;
        Debug.Log(countBalls);
        if (countBalls >= maxBalls)
        {
            PlayerTurnIsOver?.Invoke(); // ���������� �����������, ��� ��� ��������
            countBalls = 0;
        }
    }
}
