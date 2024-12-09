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
    
    // получаем количество шариков, сколько игрок может выпустить за ход
    public void GetNumberBalls(int number)
    {
        maxBalls = number;
    }
    // вызывается перед уничтожением шарика, подсчитыватся количество шариков
    public void BallCounter()
    {
        countBalls++;
        Debug.Log(countBalls);
        if (countBalls >= maxBalls)
        {
            PlayerTurnIsOver?.Invoke(); // уведомляем подписчиков, что ход завершён
            countBalls = 0;
        }
    }
}
