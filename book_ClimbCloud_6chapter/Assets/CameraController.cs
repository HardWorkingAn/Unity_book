using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        this.player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        //transform.position 은 명시한 오브젝트가 없기 때문에 C# 스크립트로 등륵한 오브젝트를 말한다.
        transform.position = new Vector3(
            transform.position.x, playerPos.y, transform.position.z);
    }
}
