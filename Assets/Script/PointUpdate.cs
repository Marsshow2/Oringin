using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUpdate : MonoBehaviour
{
    public AudioClip SoundTrack_LoadPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            AudioManager.instance.AudioPlay(SoundTrack_LoadPoint);
            collision.gameObject.GetComponent<Rolling>().RebirthPosition = transform.position;
        }
    }
}
