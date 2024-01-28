using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    //public Button playButton;
    public Image StartMask;
    public AudioClip SoundTrack_Button;
    
    //Masking
    public Image thisImage, otherImage;
    private float tick, tickx, stick, stickx;
    private bool tickLock;
    private float lockTime, startTime;

    private void Start()
    {
        Cursor.visible = true;
        StartMask.canvasRenderer.SetColor(new Vector4(0, 0, 0, 0));
    }

    void Update()
    {
        MaskingFirst();
    }

    public void PointerEnter()
    {
        AudioManager.instance.AudioPlay(SoundTrack_Button);
        StartMask.canvasRenderer.SetColor(new Vector4(0, 0, 100, 100));
    }

    public void PointerOut()
    {
        StartMask.canvasRenderer.SetColor(new Vector4(0, 0, 0, 0));
    }

    public void Firstlevel()
    {
        StartMask.canvasRenderer.SetColor(new Vector4(0,0,100,100));
        //Cursor.visible = false;
        SceneManager.LoadScene("Level0");
    }


    public void MaskingFirstEvent()
    {
        tickLock = true;
        lockTime = Time.time;
        //playButton.transform.position = new Vector3(-100, 0, 0);
    }

    public void MaskingFirst()
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
                Firstlevel();
            }
            if (tick > 0.6f) thisImage.canvasRenderer.SetColor(new Vector4(0, 0, 0, 1 - tick / 0.6f));
            otherImage.transform.localScale = new Vector3(tickx, tickx, 1);
        }

    }
}
