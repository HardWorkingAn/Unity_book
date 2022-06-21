using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{

    GameObject car;
    GameObject flag;
    GameObject distance;

    // Start is called before the first frame update
    void Start()
    {
        // car 이름을 가진 오브젝트를 찾아 car변수 저장
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");

    }

    // Update is called once per frame
    void Update()
    {
        // flag의 x 좌표랑 car x좌표를 빼서 langth 에 저장
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        //ToString F2 의미는 F는 천단위 , 출력 안하기 N는 천단위 , 출력 숫자는 소숫점 자리 개수
        this.distance.GetComponent<Text>().text = "목표 지점까지 " + length.ToString("F2") + "m";
    }
}
