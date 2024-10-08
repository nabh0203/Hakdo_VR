using System.Collections;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 1f;
    public float distance = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.y += Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = v;
    }
}
