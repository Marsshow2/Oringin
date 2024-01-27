using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class rollingController : MonoBehaviour
{
    public Rolling rolling;

    private bool faceMode;

    // Update is called once per frame
    void Update()
    {
        //internet interface
        var req = WebRequest.Create("http://"+ReadData(System.IO.Directory.GetCurrentDirectory()+"/Path.txt") +"/") as HttpWebRequest;

        var text = "";
        using (var sr = new StreamReader(req.GetResponse().GetResponseStream()))
        {
            text = sr.ReadToEnd();
        }
        if (Input.GetKeyDown(KeyCode.M)) faceMode = true;
        if (Input.GetKeyDown(KeyCode.N)) faceMode = false;
        //Jaw extending
        if(faceMode)
        {
            if (text=="True")
            {
                rolling.jawing = true;
            }
            if (text=="False")
            {
                rolling.jawing = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                rolling.jawing = true;
            }
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
            {
                rolling.jawing = false;
            }
        }
    }

    public string ReadData(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
        StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
        if (null == sr) return "192.168.6.155:8008";
        string str = sr.ReadToEnd();
        sr.Close();
        return str;
    }
}
