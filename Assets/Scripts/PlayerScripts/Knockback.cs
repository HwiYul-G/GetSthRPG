using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    // breakable Item인 pot과 공격을 받을 수 있는 player와 enemy에 대해
    // 공격 시 상태전이 처리
    
    public float thrust;
    public float knockTime;
    public float damage;

    private void OnTriggerEnter2D(Collider2D other) // 접촉 상태시
    {
        if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            other.GetComponent<pot>().Smash(); //상대방이 breakable이고, 현재가 player이면 smash
            // 즉 enemy말고 player만 pot을 break할 수 잇음
        }

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            // enemy와 player는 서로 공격할 수 있는 유일한 대상임 그에 대한 상호간 처리
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                // 공격되는 방향을 계산해 공격받으면 공격받은 대상이 뒤족으로 밀리는 처리
                Vector2 difference = hit.transform.position - this.transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                
                // Enemy인지 Player인지에 따라 따로 처리
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
