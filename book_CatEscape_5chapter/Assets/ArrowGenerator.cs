using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 1.0f; // ������ ������ 1��
    float delta = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime; // Time.deltaTime �� �����Ӱ� pc���ɰ� �����ϰ� �ð����� ���� �� �ִ�.
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab) as GameObject; // instantiate(�ν���Ʈ) �� ���ӿ�����Ʈ�� ���� destroy �� ����
            int px = Random.Range(-6, 7);//-6 ���� 6���� ���� ����
            go.transform.position = new Vector3(px, 7, 0); //
        }
    }
}
