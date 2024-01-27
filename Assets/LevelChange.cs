using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChange : MonoBehaviour
{
    public AudioClip SoundTrack_Success;

    public int Nextlevel;
    public Text time, hint;
    public float calculatedTime;
    public float delayTime = 0.5f;

    private bool levelKey;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //UI here
            calculatedTime = collision.gameObject.GetComponent<Rolling>().CalculateTime();
            if(!levelKey)
            {
                AudioManager.instance.AudioPlay(SoundTrack_Success);
                time.text = calculatedTime.ToString();
                hint.text = "Laugh to next level!";
            }

            levelKey = true;
        }
    }

    private void Update()
    {
        if(levelKey)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //Laugh anime
                Invoke("GoNextlevel", delayTime);
            }
        }
    }

    private void GoNextlevel()
    {
        SceneManager.LoadScene("Level" + Nextlevel);
    }
}
