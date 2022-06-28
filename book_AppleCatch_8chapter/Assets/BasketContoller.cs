using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketContoller : MonoBehaviour
{
    // ����� Ŭ���� ����� public �� ���� C# ��ũ��Ʈ �Ӽ����� ������ �� �� �ִ�.
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;

    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        // GameDirector C# ��ũ��Ʈ�� �ֱ� ������ GameDirector�� ã�´�.
        this.director = GameObject.Find("GameDirector");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Apple")
        {
            this.aud.PlayOneShot(this.appleSE);
            this.director.GetComponent<GameDirector>().GetApple();
        }
        else
        {
            this.aud.PlayOneShot(this.bombSE);
            this.director.GetComponent<GameDirector>().GetBomb();
        }
        Destroy(other.gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        // Physics.Raycast(ray, out hit, Mathf.Infinity) ��
        // ���� ray ��ġ���� infinity(���Ѵ�) ���̷� ���̸� ���� �浹�� �Ǹ� true �� ��ȯ
        // https://bluemeta.tistory.com/10 Raycast ����� out hit ��

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //roundToint�� �ݿø� �ؼ� int ��ȯ �ϴ� �Լ� �̹Ƿ� �������� ǥ��
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                
                // �������� ���� ���� �ֱ� ������ ��� Ŭ���ϵ� �簢�� ����� ����
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
