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
            // 1 2 3 4 5 6 7 8 9 10 중 1이나 2가 뜨면 bomb 아니면 apple이 떨어진다. 20%확률
            if(dice <= this.ratio)
            {
                item = Instantiate(bombPrefab) as GameObject;
            }
            else
            {
                item = Instantiate(applePrefab) as GameObject;
            }
            // Random.Range(a,b) 는 a <= x < b 값을 리턴 정수를 대입하면 정수값만 나옴
            // (-1.0f, 2.0f) 하면 소숫점 첫째자리 까지 포함한 랜덤값이 리턴된다.
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);

            //세터를 이용하여 매개변수를 외부에서 조절가능
            // instantiate 를 통해 이미 해당 오브젝트의 정보를 알기 떄문에 변수 설정할 때 GameObjectFind를 할 필요가 없다.
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }
}
