using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketContoller : MonoBehaviour
{
    // 오디오 클립은 사운드는 public 을 통해 C# 스크립트 속성에서 설정을 할 수 있다.
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;

    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        // GameDirector C# 스크립트가 있기 떄문에 GameDirector를 찾는다.
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
        // Physics.Raycast(ray, out hit, Mathf.Infinity) 는
        // 현제 ray 위치에서 infinity(무한대) 길이로 레이를 쏴서 충돌이 되면 true 값 반환
        // https://bluemeta.tistory.com/10 Raycast 설명과 out hit 뜻

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //roundToint는 반올림 해서 int 반환 하는 함수 이므로 정수값만 표현
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                
                // 변수에는 정수 값만 있기 때문에 어딜 클릭하든 사각형 정가운데 안착
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
