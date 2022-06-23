using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts; //총 하트 개수 (현재는 3개)
    // hp에 다라 하트 모양 변경을 위한 Sprite                       
    public Sprite fullHeart; 
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    // hp에 대한 숫자 처리를 위한 변수
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    void Start()
    {
        InitHearts();
    }

    // heart container에 든 하트의 수만큼 모양도 full로 피도 full로
    // 그리고 우리 눈에 보이게 하는 함수
    public void InitHearts()
    {
        for(int i = 0; i<heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }
    // 실시간 hp를 체크해서 하트를 반영하는 함수
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
