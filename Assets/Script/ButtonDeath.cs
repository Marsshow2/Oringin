using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDeath : MonoBehaviour
{
    //public GameObject InitialPoint;
    public Vector3 InitialPosition;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<Rolling>().Death();
        }
    }
}
