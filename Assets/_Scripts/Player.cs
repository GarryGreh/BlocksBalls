using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private int[] playerPosPresets = new int[5] { -4, -2, 0, 2, 4 };

    private void Start()
    {
        ChangePosition();
    }
    public void ChangePosition()
    {
        int rand = Random.Range(0, playerPosPresets.Length);
        transform.position = new Vector3(playerPosPresets[rand], transform.position.y, transform.position.z);
    }
}
