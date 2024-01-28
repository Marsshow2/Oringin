using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    public Image StartMask;
    public AudioClip SoundTrack_Button;

    private void Start()
    {
        Cursor.visible = true;
        StartMask.canvasRenderer.SetColor(new Vector4(0, 0, 0, 0));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Level0");
        }
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
}
