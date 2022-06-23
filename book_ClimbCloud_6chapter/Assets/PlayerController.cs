using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 680.0f; // y축 점프 힘(상수)
    float walkForce = 30.0f; // x축 이동 힘(상수)
    float maxWalkSpeed = 2.0f; // 최대 속도 제한 상수


    void Start()
    {
        // Rigidbody2D 의 컴포넌트를 사용하기 위해 비어있는 Rigidbody2D 타입의 rigid2D 에 컴포넌트를 저장한다.
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // addForce는 좌표 이동이 아닌 물리엔진을 이용한 힘으로 이동하기 떄문에 점점 이동이 점점 빨라지고 느려진다.
            // transform.up = (0,1,0)
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)){ key = 1; }
        if (Input.GetKey(KeyCode.LeftArrow)) { key = -1; }

        Debug.Log(key);
        
        //플레이어의 속도
        // 스피드 제한하기 위해 현제 이동속도를 표시 왼쪽이동하면 음수로 나오기 때문에 Abs로 절대값을 표시
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        Debug.Log(speedx);
        //스피드 제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //움직이는 방향에 따라 반전
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

    }
    void Awake()
    {
        Application.targetFrameRate = 100; // 최대 100프레임 고정
    }
}
