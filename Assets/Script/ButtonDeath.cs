using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDeath : MonoBehaviour
{
    //public GameObject InitialPoint;
    public Vector3 InitialPosition;

    public AudioClip[] SoundTrack_Death = new AudioClip[5];

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            
            AudioManager.instance.AudioPlay(SoundTrack_Death[Random.Range(0, 5)]);
            collision.gameObject.transform.position = collision.gameObject.GetComponent<Rolling>().RebirthPosition;
        }
    }
}
