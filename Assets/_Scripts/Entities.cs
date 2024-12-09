using UnityEngine;

[RequireComponent (typeof(VisualComponent))]
public abstract class Entities : MonoBehaviour
{
    public int hp = 1;
    public int armor = 0;
    public bool proof = false;
    public bool isArmored = false;
    public bool isEnemy = false;

    private VisualComponent visual;

    public virtual void Start()
    {
        visual = GetComponent<VisualComponent>();        

        // ����� ������������ ����� �������� ���� ��� ����, ����������� ���� ��� ���, � ����� ��� ���
        // ����� ��������� ���������� � ��������� ������������
        if (!isEnemy)
        {
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
        else
        {
            visual.SetHPText(hp);
            visual.SetColor(3);
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
                hp -= damage;
                if (hp <= 0)
                {
                    if (isEnemy)
                    {
                        GetComponent<EnemyShot>().Unsubscribe();
                    }
                    Destroy(this.gameObject);
                }
                else
                {
                    visual.SetHPText(hp);
                }
            }
        }
        else
        {
            return;
        }
    }
}
