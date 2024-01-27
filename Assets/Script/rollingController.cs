using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class rollingController : MonoBehaviour
{
    public Rolling rolling;

    private bool textLock;

    // Update is called once per frame
    void Update()
    {
        //internet interface
        
        var req = WebRequest.Create("http://192.168.6.155:8008/") as HttpWebRequest;

        var text = "";
        using (var sr = new StreamReader(req.GetResponse().GetResponseStream()))
        {
            text = sr.ReadToEnd();
        }
        

        //Jaw extending
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)||text=="True")
        {
            rolling.jawing = true;
            textLock = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)||(text=="False"&&textLock))
        {
            rolling.jawing = false;
            textLock = false;
        }
    }
}
