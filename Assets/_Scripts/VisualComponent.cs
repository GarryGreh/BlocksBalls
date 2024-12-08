using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VisualComponent : MonoBehaviour
{
    private TextMeshProUGUI textHP;
    private SpriteRenderer spriteRend;

    // цвет простого блока
    private Color colorBlock = new Color(1f, 0.4588236f, 0.03529412f);
    // цвет бронированного блока
    private Color armoredСolor = new Color(0.2529369f, 0.4958034f, 0.7660377f);
    // цыет неразрушаемого блока
    private Color proofColor = Color.grey;

    private const string empty = " ";
    // инициализирует компоненты: текст и отображение
    private void OnEnable()
    {
        textHP = GetComponentInChildren<TextMeshProUGUI>();
        spriteRend = GetComponent<SpriteRenderer>();
    }    
    // текст, который отображает HP или броню на блоках и врагах
    public void SetHPText(int _hp)
    {
        if (_hp >= 0)
        {
            textHP.text = _hp.ToString();
        }
        else
        {
            //textHP.text = empty;
            Transform child = transform.GetChild(0);
            if (child != null)
            {
                Destroy(child.gameObject);
            }

        }
    }

    // _status блока: 0 - неразрушаемый, 1 - разрушаемый, 2 - бронированный
    // и окрашивает соответственно
    public void SetColor(int _status)
    {
        switch (_status)
        {
            case 0: 
                spriteRend.color = proofColor;
                break;
            case 1:
                spriteRend.color = colorBlock;
                break;
            case 2:
                spriteRend.color = armoredСolor;
                break;

        }
    }
     
    // с помощью этого метода можно динамически менять спрайт на блоках и врагах
    // например при загрузке уровня, это просто как вариант, на будущее, когда будет Арт для игры
    //public void SetSprite(Sprite _sprite)
    //{        
    //    spriteRend.sprite = _sprite;
    //}
}