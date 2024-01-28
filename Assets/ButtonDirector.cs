using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDirector : MonoBehaviour
{
    public LevelChange levelChange;

    public void ButtonExit()
    {
        Debug.Log("Exit");
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void ButtonHome()
    {
        Debug.Log("Home");
        levelChange.GoHome();
    }
}
