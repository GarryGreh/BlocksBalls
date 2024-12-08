using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(VisualComponent))]
public abstract class Entities : MonoBehaviour
{
    public int hp = 1;
    public int armor = 0;
    public bool proof = false;
    public bool isArmored = false;

    private VisualComponent visual;

    private void Start()
    {
        visual = GetComponent<VisualComponent>();

        if (!proof)
        {
            if (isArmored)
            {
                visual.SetHPText(armor);
                visual.SetColor(2);
            }
            else
            {
                visual.SetHPText(hp);
                visual.SetColor(1);
            }
        }
        else
        {
            visual.SetHPText(-1);
            visual.SetColor(0);
        }
    }

    /* ��������� ����� ����� ���������� ������������ ����� ������ (����� � �����)
     ����������� ����������� �� ����, ���� ��, �� ������ �� ���������, ���� ���, �� ��������
    �� ����� � �.�. */
    public virtual void TakeDamage(int damage)
    {
        if (!proof)
        {
            if (isArmored)
            {
                if (armor > 0)
                {
                    armor--;
                    visual.SetHPText(armor);
                }
                if (armor <= 0)
                {
                    visual.SetColor(1);
                    visual.SetHPText(hp);
                    isArmored = false;
                }
                return;
            }
            else
            {
                visual.SetColor(1);
                hp -= damage;
                visual.SetHPText(hp);
                if (hp <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            return;
        }
    }
}
