using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public AudioClip[] SoundTrack_Spring = new AudioClip[4];

    private float springForce=12f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            AudioManager.instance.AudioPlay(SoundTrack_Spring[Random.Range(0, 4)]);
            collision.attachedRigidbody.AddForce(transform.up*springForce, ForceMode2D.Impulse);
        }
    }
}
