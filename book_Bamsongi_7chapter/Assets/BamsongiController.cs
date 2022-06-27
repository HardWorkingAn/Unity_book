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
        //������ �� x ����(y) 200 z���� 2000��ŭ ���� �༭ �о��.
        //y ������ 200 �ִ� ������ ����̰� ���ῡ ����� �߷��� �������� �������� ����
        //Shoot(new Vector3(0, 200, 2000));
    }

    //Collsion�� �浹�Ҷ� ���� ���� ������ �޾� ƨ�ܳ����� Trigger ����� �浹�ߴٰ� �˷��ְ� ������Ʈ�� ����Ѵ�.
    //������Ʈ�� Collsion ������� Enter(�浹�� ��)�� �ǹ�  Exit�� �浹�ϰ� �������� �� ȣ��
    void OnCollisionEnter(Collision collision)
    {
        //isKinematic�� ������Ʈ ������ �ϸ� ������ ������ ���� �ʴ´�.
        GetComponent<Rigidbody>().isKinematic = true;

        GetComponent<ParticleSystem>().Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
