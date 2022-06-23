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
    public PlayerState currentState; // 위에서 Enum으로 나열한 현재 상태
    public float speed; // 캐릭터의 walk speed
    public Rigidbody2D myRigidbody; // 물리처리를 위한 리지드바디
    private Vector3 change; //
    private Animator animator; //캐릭터 좌우상하, 공격 동작을 위한 애니매이터
    // FloatValue 타입은 사용자 지정 타입(뒤쪽 스크립트 설명 통해 설명)
    // 현재의 HP를 담는 변수
    public FloatValue currentHealth;
    // Player의 HP와 관련해서 Hearts container에게 알리기 위한 변수
    public Signal playerHealthSignal;
    // 특정 맵에서 캐릭터의 시작 위치를 정하는 변수(VectorValue타입은 사용자 지정 타입)
    public VectorValue startingPosition;
    // *구더기 코드
    //  player의 currentHealth로 게임 오버를 체크하기 위한 bool 변수
    public bool gameOver;


    // 한 번만 불려지는 함수이므로, 주된 일이 위의 변수들의 초기화 담당
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1); //Player 가 시작시 앞방향을 보도록
        // 스타트 위치 초기화
        this.transform.position = startingPosition.initialValue;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal"); // x축 방향 입력
        change.y = Input.GetAxisRaw("Vertical"); // y축 방향 입력
        if (Input.GetButtonDown("attack")&& currentState!=PlayerState.attack 
            && currentState != PlayerState.stagger) // left ctrl + 상태 전이 등 check , Attack은 미리 ctrl키로 연결해놓음
        {
            StartCoroutine(AttackCo()); // ctrl 시 공격
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove(); //평상시는 그저 이동
        }

        
    }

    private IEnumerator AttackCo() // Animation과 싱크를 맞추기 위한 공격 코루틴함수
    {
        animator.SetBool("attacking", true); //애니메이션 동작 설정
        currentState = PlayerState.attack; //상태전이
        yield return null;
        animator.SetBool("attacking", false); //동작
        yield return new WaitForSeconds(0.3f); //싱크용 코루틴
        currentState = PlayerState.walk; // 상태전이
    }

    void UpdateAnimationAndMove() // 움직이는 방향과, 걸음에 관한 애니매이션
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

    void MoveCharacter() // 캐릭터의 실질적 이동
    {
        change.Normalize();
        myRigidbody.MovePosition(this.transform.position + change * speed * Time.deltaTime);
    }

    //  플레이어가 Enemy로부터 공격받았을 시 hp감소 및 동작을 제어하기 위한 함수
    // 체력 미달 시 player 를 setactive(false)로 감춤 (Destory 함수보다 메모리 효율적)
    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise(); // HeartsContainer로 Signal 보냄
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

    private IEnumerator KnockCo(float knockTime) // 애니메이션과 상태전이 동작 맞추기 위한 코루틴
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
