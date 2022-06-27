using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    void Start()
    {
        //가로축 힘 x 높이(y) 200 z방향 2000만큼 힘을 줘서 밀어낸다.
        //y 축으로 200 주는 이유는 밤송이가 과녁에 닿기전 중력의 영향으로 떨어지기 때문
        //Shoot(new Vector3(0, 200, 2000));
    }

    //Collsion은 충돌할때 서로 물리 영향을 받아 튕겨내지만 Trigger 방식은 충돌했다고만 알려주고 오브젝트는 통과한다.
    //오브젝트가 Collsion 방식으로 Enter(충돌할 때)를 의미  Exit는 충돌하고 빠져나갈 때 호출
    void OnCollisionEnter(Collision collision)
    {
        //isKinematic은 오브젝트 정지를 하며 물리의 영향을 받지 않는다.
        GetComponent<Rigidbody>().isKinematic = true;

        GetComponent<ParticleSystem>().Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
