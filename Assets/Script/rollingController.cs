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

         var req = WebRequest.Create("http://127.0.0.1:5000/") as HttpWebRequest;

         var text = "";
         using (var sr = new StreamReader(req.GetResponse().GetResponseStream()))
         {
             text = sr.ReadToEnd();
         }


        //Jaw extending
        if (Input.GetKeyDown(KeyCode.Space) || text == "True")
        {
            rolling.jawing = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) || text != "True")
        {
            rolling.jawing = false;
        }
    }
}
