using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState; // ������ Enum���� ������ ���� ����
    public float speed; // ĳ������ walk speed
    public Rigidbody2D myRigidbody; // ����ó���� ���� ������ٵ�
    private Vector3 change; //
    private Animator animator; //ĳ���� �¿����, ���� ������ ���� �ִϸ�����
    // FloatValue Ÿ���� ����� ���� Ÿ��(���� ��ũ��Ʈ ���� ���� ����)
    // ������ HP�� ��� ����
    public FloatValue currentHealth;
    // Player�� HP�� �����ؼ� Hearts container���� �˸��� ���� ����
    public Signal playerHealthSignal;
    // Ư�� �ʿ��� ĳ������ ���� ��ġ�� ���ϴ� ����(VectorValueŸ���� ����� ���� Ÿ��)
    public VectorValue startingPosition;
    // *������ �ڵ�
    //  player�� currentHealth�� ���� ������ üũ�ϱ� ���� bool ����
    public bool gameOver;


    // �� ���� �ҷ����� �Լ��̹Ƿ�, �ֵ� ���� ���� �������� �ʱ�ȭ ���
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1); //Player �� ���۽� �չ����� ������
        // ��ŸƮ ��ġ �ʱ�ȭ
        this.transform.position = startingPosition.initialValue;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal"); // x�� ���� �Է�
        change.y = Input.GetAxisRaw("Vertical"); // y�� ���� �Է�
        if (Input.GetButtonDown("attack")&& currentState!=PlayerState.attack 
            && currentState != PlayerState.stagger) // left ctrl + ���� ���� �� check , Attack�� �̸� ctrlŰ�� �����س���
        {
            StartCoroutine(AttackCo()); // ctrl �� ����
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove(); //���ô� ���� �̵�
        }

        
    }

    private IEnumerator AttackCo() // Animation�� ��ũ�� ���߱� ���� ���� �ڷ�ƾ�Լ�
    {
        animator.SetBool("attacking", true); //�ִϸ��̼� ���� ����
        currentState = PlayerState.attack; //��������
        yield return null;
        animator.SetBool("attacking", false); //����
        yield return new WaitForSeconds(0.3f); //��ũ�� �ڷ�ƾ
        currentState = PlayerState.walk; // ��������
    }

    void UpdateAnimationAndMove() // �����̴� �����, ������ ���� �ִϸ��̼�
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void MoveCharacter() // ĳ������ ������ �̵�
    {
        change.Normalize();
        myRigidbody.MovePosition(this.transform.position + change * speed * Time.deltaTime);
    }

    //  �÷��̾ Enemy�κ��� ���ݹ޾��� �� hp���� �� ������ �����ϱ� ���� �Լ�
    // ü�� �̴� �� player �� setactive(false)�� ���� (Destory �Լ����� �޸� ȿ����)
    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise(); // HeartsContainer�� Signal ����
        if (currentHealth.RuntimeValue > 0)
        {
            gameOver = false;
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            gameOver = true;
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator KnockCo(float knockTime) // �ִϸ��̼ǰ� �������� ���� ���߱� ���� �ڷ�ƾ
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
