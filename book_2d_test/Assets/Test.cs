using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Test : MonoBehaviour {
    // Start is called before the first frame update
    float timer = 2.0f;
    float nexttime = 0.0f;
    
    void Start()
    {
        // vector2 활용에제
        Vector2 vector = new Vector2(3.0f, 4.0f);

        vector.x += 15.0f;
        vector.y += 20.0f;

        Debug.Log(vector);

        Vector2 StartPos = new Vector2(5.0f, 6.0f);
        Vector2 EndPos = new Vector2(9.0f, 12.0f);

        Vector2 dir = EndPos - StartPos;

        Debug.Log(dir);

        //벡터의 대각선 길이
        float dirLen = dir.magnitude;
        Debug.Log(dirLen);

        /*
         //클래스 활용 예제
         Player player = new Player();

        player.attack(20);
        player.power();
        */
    }

    // Update is called once per frame
    void Update()
    {

    }
    void delaytest() {
        Debug.Log("delay test");
    }
    

}
public class Player {


    private int HP = 100;
    private int POWER = 50;

    public void attack(int a)
    {
        Debug.Log("공격 " + a + " 대미지");
        this.HP -= a;
        Debug.Log("HP : " + HP);
    }

    public void power()
    {
        Debug.Log("공격 " + this.POWER + " 대미지");
        this.HP -= this.POWER;
        Debug.Log("잔여 HP " + this.HP);
    }

}
