using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public AudioClip SoundTrack_Button;

    public GameObject spur;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            AudioManager.instance.AudioPlay(SoundTrack_Button);
            ButtonDown();
        }
    }

    public void ButtonDown()
    {
        Destroy(spur);
    }
}
