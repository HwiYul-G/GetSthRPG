using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    // breakable Item�� pot�� ������ ���� �� �ִ� player�� enemy�� ����
    // ���� �� �������� ó��
    
    public float thrust;
    public float knockTime;
    public float damage;

    private void OnTriggerEnter2D(Collider2D other) // ���� ���½�
    {
        if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            other.GetComponent<pot>().Smash(); //������ breakable�̰�, ���簡 player�̸� smash
            // �� enemy���� player�� pot�� break�� �� ����
        }

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            // enemy�� player�� ���� ������ �� �ִ� ������ ����� �׿� ���� ��ȣ�� ó��
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                // ���ݵǴ� ������ ����� ���ݹ����� ���ݹ��� ����� �������� �и��� ó��
                Vector2 difference = hit.transform.position - this.transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                
                // Enemy���� Player������ ���� ���� ó��
                if (other.gameObject.CompareTag("Enemy") && other.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime,damage);
                }
                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                    }
                }

            }
        }
    }
}
