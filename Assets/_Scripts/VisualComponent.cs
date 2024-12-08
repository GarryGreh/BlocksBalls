using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VisualComponent : MonoBehaviour
{
    private TextMeshProUGUI textHP;
    private SpriteRenderer spriteRend;

    // ���� �������� �����
    private Color colorBlock = new Color(1f, 0.4588236f, 0.03529412f);
    // ���� �������������� �����
    private Color armored�olor = new Color(0.2529369f, 0.4958034f, 0.7660377f);
    // ���� �������������� �����
    private Color proofColor = Color.grey;

    private const string empty = " ";
    // �������������� ����������: ����� � �����������
    private void OnEnable()
    {
        textHP = GetComponentInChildren<TextMeshProUGUI>();
        spriteRend = GetComponent<SpriteRenderer>();
    }    
    // �����, ������� ���������� HP ��� ����� �� ������ � ������
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

    // _status �����: 0 - �������������, 1 - �����������, 2 - �������������
    // � ���������� ��������������
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
                spriteRend.color = armored�olor;
                break;

        }
    }
     
    // � ������� ����� ������ ����� ����������� ������ ������ �� ������ � ������
    // �������� ��� �������� ������, ��� ������ ��� �������, �� �������, ����� ����� ��� ��� ����
    //public void SetSprite(Sprite _sprite)
    //{        
    //    spriteRend.sprite = _sprite;
    //}
}