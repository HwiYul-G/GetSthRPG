using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts; //�� ��Ʈ ���� (����� 3��)
    // hp�� �ٶ� ��Ʈ ��� ������ ���� Sprite                       
    public Sprite fullHeart; 
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    // hp�� ���� ���� ó���� ���� ����
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    void Start()
    {
        InitHearts();
    }

    // heart container�� �� ��Ʈ�� ����ŭ ��絵 full�� �ǵ� full��
    // �׸��� �츮 ���� ���̰� �ϴ� �Լ�
    public void InitHearts()
    {
        for(int i = 0; i<heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }
    // �ǽð� hp�� üũ�ؼ� ��Ʈ�� �ݿ��ϴ� �Լ�
    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.RuntimeValue / 2;
        for(int i = 0; i<heartContainers.RuntimeValue; i++)
        {
            if (i <= tempHealth-1)
            {
                //Full Heart
                hearts[i].sprite = fullHeart;
            }else if (i >= tempHealth)
            {
                // empty Heart
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                // half full heart
                hearts[i].sprite = halfFullHeart;
            }
        }
    }
}
