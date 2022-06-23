using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Powerup
{
    // Powerup�̶� ��ũ��Ʈ�� ��� �޾Ƽ�
    // heart�� ��������� �ϸ� powerup�� �̿���
    // (Powerup�� �� �Ӹ��ƴ϶� ���� ������ ������ų �� �ְ� ���� ����)
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amountToIncrease;

    // ��Ʈ�� ��������� �װ��� Player��� ������ ó�� ����
    // ��Ʈ�� get�ϰ� �ǰ� hp�� �����ǰ� �� ��翡 ���� update�� �̷����
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
