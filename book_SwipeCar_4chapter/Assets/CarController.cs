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
        //�巡�� ���� ��ŭ �ڵ��� �ӵ�
        if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;

            float swipeLength = endPos.x - startPos.x;

            this.speed = swipeLength / 500.0f;

            //ȿ������ ���
            GetComponent<AudioSource>().Play();
            
        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            this.speed = 0.2f;
        }
        */
        //�ش� ���ǵ� ��ŭ ������Ʈ�� �̵� ��Ű�� �Լ�
        transform.Translate(this.speed, 0, 0); 

        //�� update ���� �ӵ� ���� 
        this.speed *= 0.98f;
        
    }
}
