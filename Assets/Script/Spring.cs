using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private float springForce=12f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            collision.attachedRigidbody.AddForce(transform.up*springForce, ForceMode2D.Impulse);
        }
    }
}
