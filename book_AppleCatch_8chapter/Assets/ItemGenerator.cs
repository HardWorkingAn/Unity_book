using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0;
    int ratio = 2;
    float speed = -0.03f;
    
    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            // 1 2 3 4 5 6 7 8 9 10 �� 1�̳� 2�� �߸� bomb �ƴϸ� apple�� ��������. 20%Ȯ��
            if(dice <= this.ratio)
            {
                item = Instantiate(bombPrefab) as GameObject;
            }
            else
            {
                item = Instantiate(applePrefab) as GameObject;
            }
            // Random.Range(a,b) �� a <= x < b ���� ���� ������ �����ϸ� �������� ����
            // (-1.0f, 2.0f) �ϸ� �Ҽ��� ù°�ڸ� ���� ������ �������� ���ϵȴ�.
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);

            //���͸� �̿��Ͽ� �Ű������� �ܺο��� ��������
            // instantiate �� ���� �̹� �ش� ������Ʈ�� ������ �˱� ������ ���� ������ �� GameObjectFind�� �� �ʿ䰡 ����.
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }
}
