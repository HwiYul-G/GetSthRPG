using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Powerup
{
    // Powerup이란 스크립트를 상속 받아서
    // heart를 가까워지게 하면 powerup을 이용함
    // (Powerup은 피 뿐만아니라 여러 가지를 증가시킬 수 있게 변형 가능)
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amountToIncrease;

    // 하트와 가까워지고 그것이 Player라면 별도의 처리 없이
    // 하트를 get하게 되고 hp가 증가되고 그 모양에 대한 update도 이루어짐
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.RuntimeValue += amountToIncrease;
            if(playerHealth.initialValue > heartContainers.RuntimeValue * 3f)
            {
                playerHealth.initialValue = heartContainers.RuntimeValue * 3f;
            }
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
