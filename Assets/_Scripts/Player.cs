using UnityEngine;

public class Player : MonoBehaviour
{
    private int[] playerPosPresets = new int[5] { -4, -2, 0, 2, 4 };
    [SerializeField]
    private int health = 50;

    private bool isReload;

    private void Awake()
    {
        ChangePosition();
    }
    public void ChangePosition()
    {
        int rand = Random.Range(0, playerPosPresets.Length);
        transform.position = new Vector3(playerPosPresets[rand], transform.position.y, transform.position.z);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            // проиграл
        }

        ChangePosition();
    }
}
