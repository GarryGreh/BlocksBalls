using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    // для изменения цвета, если есть броня
    private SpriteRenderer render;

    // цвет простого блока
    private Color colorBlock = new Color(1f, 0.4588236f, 0.03529412f);
    // цвет бронированного блока
    private Color armoredBlock = new Color(0.2529369f, 0.4958034f, 0.7660377f);

    // прочность блока
    [SerializeField]
    private int hp = 1;
    [SerializeField]
    private int armor = 1;

    private bool isArmored;

    private TextMeshProUGUI textHP;

    private void OnEnable()
    {
        textHP = GetComponentInChildren<TextMeshProUGUI>();

        if (isArmored)
        {
            textHP.text = armor.ToString();
        }
        else
        {
            textHP.text = hp.ToString();
        }
    }
}
