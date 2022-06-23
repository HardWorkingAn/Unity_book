using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 680.0f; // y�� ���� ��(���)
    float walkForce = 30.0f; // x�� �̵� ��(���)
    float maxWalkSpeed = 2.0f; // �ִ� �ӵ� ���� ���


    void Start()
    {
        // Rigidbody2D �� ������Ʈ�� ����ϱ� ���� ����ִ� Rigidbody2D Ÿ���� rigid2D �� ������Ʈ�� �����Ѵ�.
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // addForce�� ��ǥ �̵��� �ƴ� ���������� �̿��� ������ �̵��ϱ� ������ ���� �̵��� ���� �������� ��������.
            // transform.up = (0,1,0)
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //�¿� �̵�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)){ key = 1; }
        if (Input.GetKey(KeyCode.LeftArrow)) { key = -1; }

        Debug.Log(key);
        
        //�÷��̾��� �ӵ�
        // ���ǵ� �����ϱ� ���� ���� �̵��ӵ��� ǥ�� �����̵��ϸ� ������ ������ ������ Abs�� ���밪�� ǥ��
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        Debug.Log(speedx);
        //���ǵ� ����
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //�����̴� ���⿡ ���� ����
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

    }
    void Awake()
    {
        Application.targetFrameRate = 100; // �ִ� 100������ ����
    }
}
