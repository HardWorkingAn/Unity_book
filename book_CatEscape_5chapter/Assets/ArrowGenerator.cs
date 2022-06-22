using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 1.0f; // 변수로 저장한 1초
    float delta = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime; // Time.deltaTime 은 프레임과 pc성능과 무관하게 시간값을 쌓을 수 있다.
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab) as GameObject; // instantiate(인스턴트) 는 게임오브젝트를 생성 destroy 는 삭제
            int px = Random.Range(-6, 7);//-6 부터 6까지 랜덤 생성
            go.transform.position = new Vector3(px, 7, 0); //
        }
    }
}
