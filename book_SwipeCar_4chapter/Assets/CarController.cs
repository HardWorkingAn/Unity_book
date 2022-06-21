using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //드래그 길이 만큼 자동차 속도
        if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;

            float swipeLength = endPos.x - startPos.x;

            this.speed = swipeLength / 500.0f;

            //효과음을 재생
            GetComponent<AudioSource>().Play();
            
        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            this.speed = 0.2f;
        }
        */
        //해당 스피드 만큼 오브젝트를 이동 시키는 함수
        transform.Translate(this.speed, 0, 0); 

        //매 update 마다 속도 감속 
        this.speed *= 0.98f;
        
    }
}
