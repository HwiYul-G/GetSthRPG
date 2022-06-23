using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    // ��������, ä��, ����, ���ǵ� �� Player�� ����� ���� 
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject deathEffect;

    private void Awake() // �ʱ�ȭ // Start �Լ����� ���� �����
    {
        health = maxHealth.initialValue;
    }
    // Player�� ���ݽ� �޾� ������ damage�� �޾��� ���� ����
    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DeathEffect();
            Destroy(this.gameObject); // destory���� setactive(false)�� �����Ұ�
        }
    }
     // ���� ȿ�� �Լ� (enemy�� ������ ������)
    private void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect,this.transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
    // ������ �޾��� �� ����ǰ� �ϴ� �Լ�
    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }
    // ���� �Լ��� �������� �Լ��� �ڷ�ƾ�� ���� ��ũ�� ����
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null )
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
