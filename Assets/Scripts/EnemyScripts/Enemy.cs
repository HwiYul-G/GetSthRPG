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
    // 상태전이, 채력, 공격, 스피드 등 Player와 비슷한 변수 
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject deathEffect;

    private void Awake() // 초기화 // Start 함수보다 먼저 실행됨
    {
        health = maxHealth.initialValue;
    }
    // Player가 공격시 받아 쓰게할 damage를 받앗을 시의 변수
    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DeathEffect();
            Destroy(this.gameObject); // destory보단 setactive(false)로 변경할것
        }
    }
     // 죽음 효과 함수 (enemy의 투명도를 조절함)
    private void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect,this.transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
    // 공격을 받았을 시 수행되게 하는 함수
    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }
    // 위의 함수의 실질적인 함수로 코루틴을 통해 싱크를 맞춤
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
