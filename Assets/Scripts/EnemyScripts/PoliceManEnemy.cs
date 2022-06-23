using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoliceManEnemy : Enemy
{
    // PoliceManEnemy�� Enemy Ŭ������ ��ӹ޾Ƽ� ������ Knock ó���� �ʿ� ����
    // �� Ŭ������ ���� Enemy�� �ڱ� �ڸ��� ��Ű�ٰ� Range�̳��� player�� ������ �߰�
    public Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius; // �߰� ������
    public float attackRadius;
    public Transform homePosition; // �ڱ� ���� ��ġ
    public Animator anim;

    // �ʱ�ȭ
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }
    // ������ ���� upate�� �ƴ� ��Ģ���� �������� update �Ǵ� FixedUpdate�� ���
    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance() // target�� Player���� �Ÿ��� üũ�� �߰�, ���� ���� ����
    {
        if(Vector3.Distance(target.position, this.transform.position) <= chaseRadius) // �߰ݹ��� ���̰�
        {
            if(Vector3.Distance(target.position, this.transform.position) > attackRadius) // ���� ���� ���� ��� �Ѿƿ�
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
            else // ���ݹ��� ���� ���
            {
                Vector3 temp = Vector3.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);

                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);

                ChangeState(EnemyState.attack);
                anim.SetBool("attacking", true);
            }
        }
        else if (Vector3.Distance(target.position, this.transform.position) > chaseRadius) // �߰� ���� ���� ���
        {
            
            anim.SetBool("walking", false);
            anim.SetBool("attacking", false);
        }
    }

    // Player�� ����ϰ� x���� �¿�  y���� ���Ϸ� �� ����
    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    // Player�� ��ġ�� ���� ������ �����ؼ� �̵��ϰ� ��
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

    // ���º�ȭ �Լ� �θ� Ŭ������ Enemy�� enum�� �̿�
    public void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
