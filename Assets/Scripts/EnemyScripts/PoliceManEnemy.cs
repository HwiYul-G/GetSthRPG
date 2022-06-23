using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoliceManEnemy : Enemy
{
    // PoliceManEnemy는 Enemy 클래스를 상속받아서 죽음과 Knock 처리는 필요 없음
    // 이 클래스를 받은 Enemy는 자기 자리를 지키다가 Range이내로 player가 들어오면 추격
    public Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius; // 추격 반지름
    public float attackRadius;
    public Transform homePosition; // 자기 고정 위치
    public Animator anim;

    // 초기화
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }
    // 프레임 단위 upate가 아닌 규칙적인 간격으로 update 되는 FixedUpdate를 사용
    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance() // target인 Player와의 거리를 체크해 추격, 공격 여부 적용
    {
        if(Vector3.Distance(target.position, this.transform.position) <= chaseRadius) // 추격범위 내이고
        {
            if(Vector3.Distance(target.position, this.transform.position) > attackRadius) // 공격 범위 밖인 경우 쫓아와
            {
                if (currentState == EnemyState.idle || currentState == EnemyState.walk || currentState == EnemyState.attack && currentState != EnemyState.stagger)
                {
                    Vector3 temp = Vector3.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);

                    changeAnim(temp - transform.position);
                    myRigidbody.MovePosition(temp);

                    ChangeState(EnemyState.walk);
                    anim.SetBool("walking", true);
                    anim.SetBool("attacking", false);
                }
            }
            else // 공격범위 내인 경우
            {
                Vector3 temp = Vector3.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);

                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);

                ChangeState(EnemyState.attack);
                anim.SetBool("attacking", true);
            }
        }
        else if (Vector3.Distance(target.position, this.transform.position) > chaseRadius) // 추격 범위 밖인 경우
        {
            
            anim.SetBool("walking", false);
            anim.SetBool("attacking", false);
        }
    }

    // Player와 비슷하게 x축은 좌우  y축은 상하로 값 설정
    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    // Player의 위치에 따라 방향을 조정해서 이동하게 함
    public void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if(direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if(direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    // 상태변화 함수 부모 클래스인 Enemy의 enum을 이용
    public void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
