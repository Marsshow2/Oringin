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

    //Masking
    public Image thisImage, otherImage;
    private float tick, tickx, stick, stickx;
    private bool tickLock;
    private float lockTime, startTime;

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
            if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
            {
                //Laugh anime
                Invoke("GoNextlevel", delayTime);
            }
        }
        MaskingHome();
    }

    private void GoNextlevel()
    {
        if(Nextlevel==0)
        {
            GoHome();
        }
        SceneManager.LoadScene("Level" + Nextlevel);
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Start");
    }

    public void Masking()
    {
        tickLock = true;
        if (tickLock)
        {
            if (Time.time - lockTime <= 1)
            {
                tick = ((Time.time - lockTime) / 1.0f);
                tickx = 60f - tick * 59f;
            }
            else
            {
                tick = 100;
                //SceneManager.LoadScene("Level0");
                GoNextlevel();
            }
            if (tick > 0.6f) thisImage.canvasRenderer.SetColor(new Vector4(0, 0, 0, 1 - tick / 0.6f));
            otherImage.transform.localScale = new Vector3(tickx, tickx, 1);
        }
    }
    public void MaskingHomeEvent()
    {
        tickLock = true;
        lockTime = Time.time;
    }

    public void MaskingHome()
    {
        if (tickLock)
        {
            if (Time.time - lockTime <= 1)
            {
                tick = ((Time.time - lockTime) / 1.0f);
                tickx = 60f - tick * 59f;
            }
            else
            {
                tick = 100;
                //SceneManager.LoadScene("Level0");
                GoHome();
            }
            if (tick > 0.6f) thisImage.canvasRenderer.SetColor(new Vector4(0, 0, 0, 1 - tick / 0.6f));
            otherImage.transform.localScale = new Vector3(tickx, tickx, 1);
        }

    }
}
