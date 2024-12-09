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
    // ���� �����
    private Color enemyColor = Color.red;

    private Entities entities;

    private const string empty = " ";
    // �������������� ����������: ����� � �����������
    private void Awake()
    {
        textHP = GetComponentInChildren<TextMeshProUGUI>();
        spriteRend = GetComponent<SpriteRenderer>();
        
    }
    private void Start()
    {
        entities = GetComponentInChildren<Entities>();
        if (entities != null)
        {
            if (entities.proof)
            {
                //textHP.text = " ";
                Transform child = transform.GetChild(0);
                if (child != null)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
    // �����, ������� ���������� HP ��� ����� �� ������ � ������
    public void SetHPText(int _hp)
    {
        //if (!_proof)
        //{
            textHP.text = _hp.ToString();
        //}
        //else
        //{
        //    Transform child = transform.GetChild(0);
        //    if (child != null)
        //    {
        //        Destroy(child.gameObject);
        //    }

        //}
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
            case 3:
                spriteRend.color = enemyColor;
                break;

        }
    }    
}