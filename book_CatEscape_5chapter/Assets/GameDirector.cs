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

    // �浹���� �� hp�� ���ҽ�Ű�� �޼ҵ�
    public void DecreaseHp()
    {
        //UnityEngine.UI �� ���̺귯���� ��ӹ޾� ���
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }

    // ���� Ȯ���� ���� �ϱ� ���� ������ ���� ������ 100
    void Awake()
    {
        Application.targetFrameRate = 100;
    }
}
