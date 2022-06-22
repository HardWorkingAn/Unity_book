using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        //�浹�� �����ϱ����� player ������Ʈ�� ����
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // x y z ��ǥ 
        transform.Translate(0, -0.1f, 0);

        //������Ʈ ����
        if(transform.position.y< -5.0f)
        {
            Destroy(gameObject);
        }

        //�浹����
        Vector2 p1 = transform.position; //ȭ�� �߽� ��ǥ
        Vector2 p2 = player.transform.position; // �÷��̾� �߽� ��ǥ
        
        Vector2 dir = p1 - p2; //p219 p1 �� p2�� �߽��� ������ ����ϱ� ���� ��ǥ�� ����
        float d = dir.magnitude; //p1 �� p2�� �߽��� ������ �Ÿ� 2����ǥ(��Ÿ�������) ������ �ϱ� ������ - ��ǥ�� ����x

        float r1 = 0.5f; // ȭ�� �߽� �ݰ� ����(������) ũ��
        float r2 = 1.0f; // �÷��̾� �߽� �ݰ� ����(������) ũ��

        if(d < r1 + r2)
        {
            //GameDirector�� �÷��̾�� ȭ���� �浹�ߴٰ� ����
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy(gameObject);
        }
    }
}
