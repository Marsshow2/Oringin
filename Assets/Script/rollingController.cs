using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class rollingController : MonoBehaviour
{
    public Rolling rolling;
    // Update is called once per frame
    void Update()
    {
        //internet interface
        /*
        var req = WebRequest.Create("http://localhost:5000/") as HttpWebRequest;

        var text = "";
        using (var sr = new StreamReader(req.GetResponse().GetResponseStream()))
        {
            text = sr.ReadToEnd();
        }
        */

        //Jaw extending
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
