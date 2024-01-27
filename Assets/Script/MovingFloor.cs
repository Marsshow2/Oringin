using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;

    void Update()
    {
        float newPosition = Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = new Vector2(newPosition, transform.position.y);
    }
}