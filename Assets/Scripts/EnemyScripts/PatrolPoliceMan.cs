using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoliceMan: PoliceManEnemy
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

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
