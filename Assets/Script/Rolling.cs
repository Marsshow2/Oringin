using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    public Vector3 RebirthPosition;
    private float BounceAngle; 

    public bool jawing;
    private bool jawLock;
    private float jawScale = 3.0f;
    private float jawForce = 5f;

    private float RotationSpeed = 1f;
    private float moveSpeed = 2f;

    public Rigidbody2D thisRigid;
    public GameObject triangle;

    private float scaleY, tscaleY;

    private bool ground;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;
        GetComponent<SpriteRenderer>().enabled = false;
        scaleY = transform.localScale.y;
        tscaleY = triangle.transform.localScale.y;
    }

    private void FixedUpdate()
    {
        if (transform.up.y > 0)
        {
            triangle.transform.localPosition = new Vector3(0f, 0.71f, 0f);
            triangle.transform.Rotate(0f, 0f, 180f);
        }
        else
        {
            triangle.transform.localPosition = new Vector3(0f, -0.71f, 0f);
            triangle.transform.Rotate(0f, 0f, 180f);
        }
        
        if (jawing)
        {
            if (jawLock)
            {
                transform.localScale = new Vector3(transform.localScale.x, scaleY+jawScale, transform.localScale.z);
                triangle.GetComponent<SpriteRenderer>().enabled = false;
                if(ground)
                {
                    if(transform.up.y>0)
                        this.GetComponent<Rigidbody2D>().AddForce(transform.up * jawForce,ForceMode2D.Impulse);
                    else
                        this.GetComponent<Rigidbody2D>().AddForce(-transform.up * jawForce, ForceMode2D.Impulse);
                    ground = false;
                }
                jawLock = false;
            }
        }
        else
        {
            if(!jawLock)
            {
                transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
                triangle.GetComponent<SpriteRenderer>().enabled = true;
                jawLock = true;
            }
            
            transform.Rotate(0, 0, -RotationSpeed);
            thisRigid.velocity = new Vector2(moveSpeed, thisRigid.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            ground = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = false;
        }
    }

    public float CalculateTime()
    {
        return Time.time - startTime;
    }
}
