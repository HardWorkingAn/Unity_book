using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        //충돌을 감지하기위해 player 오브젝트를 저장
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // x y z 좌표 
        transform.Translate(0, -0.1f, 0);

        //오브젝트 삭제
        if(transform.position.y< -5.0f)
        {
            Destroy(gameObject);
        }

        //충돌감지
        Vector2 p1 = transform.position; //화살 중심 좌표
        Vector2 p2 = player.transform.position; // 플레이어 중심 좌표
        
        Vector2 dir = p1 - p2; //p219 p1 과 p2의 중심점 끼리의 계산하기 위한 좌표값 생성
        float d = dir.magnitude; //p1 과 p2의 중심점 끼리의 거리 2차좌표(피타고라스정의) 제곱을 하기 떄문에 - 좌표는 생각x

        float r1 = 0.5f; // 화살 중심 반경 설정(반지름) 크기
        float r2 = 1.0f; // 플레이어 중심 반경 설정(반지름) 크기

        if(d < r1 + r2)
        {
            //GameDirector에 플레이어와 화살이 충돌했다고 전달
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy(gameObject);
        }
    }
}
