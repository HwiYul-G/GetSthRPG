using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoliceMan: PoliceManEnemy
{
    // 기본형태를 Enemy Class를 상속받은 PoliceManEnemy로 두고, 그것을 또 상속받음
    // animation과 동작 원리는 동일하지만
    // PatrolPoliceMan은 특정 위치의 position 값을 배열로 가지고 그 위치를 탐색
    public Transform[] path; // 탐색할 위치 배열
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    // PatrolPoliceMan이 target인 Player의 위치를 check하는 것과 동일하되, 기본으로 고정이 아니라 이동하게함
    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, this.transform.position) <= chaseRadius) // 추격범위 내이고
        {
            if (Vector3.Distance(target.position, this.transform.position) > attackRadius) // 공격 범위 밖인 경우 쫓아와
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
            if (Vector3.Distance(this.transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(this.transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);

                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                anim.SetBool("walking", true);
                anim.SetBool("attacking", false);
            }
            else
            {
                ChangeGoal();
            }
        }
    }

    // 이동할 위치를 배열 변수로 받았기 때문에 현재 위치가 몇인지 check하고
    // 다음 이동할 target 위치로 이동하는 것을 처리하는 함수
    private void ChangeGoal()
    {
        if(currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
