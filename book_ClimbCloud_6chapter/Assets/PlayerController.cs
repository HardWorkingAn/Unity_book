using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f; // y�� ���� ��(���)
    float walkForce = 30.0f; // x�� �̵� ��(���)
    float maxWalkSpeed = 2.0f; // �ִ� �ӵ� ���� ���


    void Start()
    {
        // Rigidbody2D �� ������Ʈ�� ����ϱ� ���� ����ִ� Rigidbody2D Ÿ���� rigid2D �� ������Ʈ�� �����Ѵ�.
        this.rigid2D = GetComponent<Rigidbody2D>();
        //�ִϸ����͵� ������Ʈ �߰��߱� ������ ������ ����
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ����
        // velocity.y �� ������ �� y������ �ö󰡴� �ӵ��� �ǹ��ϸ� ���� ������ ���ϰ� �Ѵ�.
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            // addForce�� ��ǥ �̵��� �ƴ� ���������� �̿��� ������ �̵��ϱ� ������ ���� �̵��� ���� �������� ��������.
            // transform.up = (0,1,0) �ǹ�
            this.rigid2D.AddForce(transform.up * this.jumpForce);

            //���� �ִϸ��̼����� ��ȯ
            this.animator.SetTrigger("JumpTrigger");
        }

        //�¿� �̵�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)){ key = 1; }
        if (Input.GetKey(KeyCode.LeftArrow)) { key = -1; }

        
        //�÷��̾��� �ӵ�
        // ���ǵ� �����ϱ� ���� ���� �̵��ӵ��� ǥ�� �����̵��ϸ� ������ ������ ������ Abs�� ���밪�� ǥ��
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        //���ǵ� ����. ���ǵ� ������ 2�� �Ѵ� �ϴ��� 1.9~ ���� ���ӵ��� �ѹ��� ���̸� 2.7~2.8 ���� ���� �� �ִ�.
        if (speedx < this.maxWalkSpeed)
        {
            //�¿� �ӵ� �ֱ�
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        
        //�����̴� ���⿡ ���� ����
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        //�÷��̾� �ӵ��� ���� �ִϸ��̼� �ӵ��� �ٲ۴�.
        
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }
        
      

        //�÷��̾ ��������� ó������ ����
        if (transform.position.y < -10)
        {
            //���� ������ �ٸ� ���
            /*
            this.rigid2D.velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(0, 0, 0);
            */
            //å ������ ���
            SceneManager.LoadScene("GameScene");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("��~");
        SceneManager.LoadScene("ClearScene");
        
    }
    /*
    void Awake()
    {
        Application.targetFrameRate = 100; // �ִ� 100������ ����
    }
    */
}
