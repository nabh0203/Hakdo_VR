using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f; // 플레이어의 움직임 속도를 조절합니다.

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            movement.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.z -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x += 1;
        }

        transform.position += movement * speed * Time.deltaTime;
    }
}
