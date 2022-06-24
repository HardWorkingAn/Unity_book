using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f; // y축 점프 힘(상수)
    float walkForce = 30.0f; // x축 이동 힘(상수)
    float maxWalkSpeed = 2.0f; // 최대 속도 제한 상수


    void Start()
    {
        // Rigidbody2D 의 컴포넌트를 사용하기 위해 비어있는 Rigidbody2D 타입의 rigid2D 에 컴포넌트를 저장한다.
        this.rigid2D = GetComponent<Rigidbody2D>();
        //애니메이터도 컴포넌트 추가했기 때문에 변수에 저장
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 점프
        // velocity.y 는 점프할 때 y축으로 올라가는 속도를 의미하며 연속 점프를 못하게 한다.
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            // addForce는 좌표 이동이 아닌 물리엔진을 이용한 힘으로 이동하기 떄문에 점점 이동이 점점 빨라지고 느려진다.
            // transform.up = (0,1,0) 의미
            this.rigid2D.AddForce(transform.up * this.jumpForce);

            //점프 애니메이션으로 전환
            this.animator.SetTrigger("JumpTrigger");
        }

        //좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)){ key = 1; }
        if (Input.GetKey(KeyCode.LeftArrow)) { key = -1; }

        
        //플레이어의 속도
        // 스피드 제한하기 위해 현제 이동속도를 표시 왼쪽이동하면 음수로 나오기 때문에 Abs로 절대값을 표시
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        //스피드 제한. 스피드 제한을 2를 한다 하더라도 1.9~ 에서 가속도를 한번더 붙이면 2.7~2.8 까지 나올 수 있다.
        if (speedx < this.maxWalkSpeed)
        {
            //좌우 속도 주기
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        
        //움직이는 방향에 따라 반전
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        //플레이어 속도에 맞춰 애니메이션 속도를 바꾼다.
        
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }
        
      

        //플레이어가 떨어질경우 처음부터 시작
        if (transform.position.y < -10)
        {
            //직접 생각한 다른 방법
            /*
            this.rigid2D.velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(0, 0, 0);
            */
            //책 따라한 방법
            SceneManager.LoadScene("GameScene");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("골~");
        SceneManager.LoadScene("ClearScene");
        
    }
    /*
    void Awake()
    {
        Application.targetFrameRate = 100; // 최대 100프레임 고정
    }
    */
}
