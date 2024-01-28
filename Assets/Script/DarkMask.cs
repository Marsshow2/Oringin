using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DarkMask : MonoBehaviour
{
    public Image thisImage, otherImage;
    private float tick, tickx, stick, stickx;
    private bool tickLock;
    private float lockTime, startTime;

    private void Start()
    {
        startTime = Time.time;
        thisImage.canvasRenderer.SetColor(new Vector4(0, 0, 0, 0));
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            tickLock = true;
            lockTime = Time.time;
        }
        if(tickLock)
        {
            if(Time.time-lockTime<=1)
            {
                tick = ((Time.time - lockTime) / 1.0f);
                tickx = 60f - tick * 59f;
            }
            else
            {
                tick = 100;
                SceneManager.LoadScene("Level0");
            }
            if(tick>0.6f) thisImage.canvasRenderer.SetColor(new Vector4(0, 0, 0, 1-tick/0.6f));
            otherImage.transform.localScale = new Vector3(tickx, tickx, 1); 
        }
        else
        {
            if(Time.time-startTime<=1)
            {
                stick=(1-(Time.time-startTime/1.0f));
                stickx=tick*59f+59f;
            }
        }
    }
}
