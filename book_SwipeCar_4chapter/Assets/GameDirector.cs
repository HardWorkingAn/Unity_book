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
        // car �̸��� ���� ������Ʈ�� ã�� car���� ����
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");

    }

    // Update is called once per frame
    void Update()
    {
        // flag�� x ��ǥ�� car x��ǥ�� ���� langth �� ����
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        //ToString F2 �ǹ̴� F�� õ���� , ��� ���ϱ� N�� õ���� , ��� ���ڴ� �Ҽ��� �ڸ� ����
        this.distance.GetComponent<Text>().text = "��ǥ �������� " + length.ToString("F2") + "m";
    }
}
