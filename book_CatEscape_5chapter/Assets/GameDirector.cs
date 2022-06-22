using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;

    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }

    // 충돌했을 때 hp를 감소시키는 메소드
    public void DecreaseHp()
    {
        //UnityEngine.UI 를 라이브러리를 상속받아 사용
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }

    // 게임 확인을 쉽게 하기 위해 프레임 조절 프레임 100
    void Awake()
    {
        Application.targetFrameRate = 100;
    }
}
