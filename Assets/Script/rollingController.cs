using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using NativeWebSocket;
using UnityEngine;

public class rollingController : MonoBehaviour
{
    public Rolling rolling;

    private bool faceMode;

    private WebSocket webSocket;

    private bool jawing;
    private string mes;

    private async void Start()
    {
        webSocket = new WebSocket(ReadData(System.IO.Directory.GetCurrentDirectory() + "/Path.txt"));

        webSocket.OnMessage += message =>
        {
            var msg = BitConverter.ToString(message);
            mes = msg;
            jawing = msg == "31";
        };

        webSocket.OnError += e =>
        {
            Debug.Log("Error! " + e);
        };

        await webSocket.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        #if !UNITY_WEBGL || UNITY_EDITOR
        webSocket.DispatchMessageQueue();
        #endif

        if (Input.GetKeyDown(KeyCode.M)) faceMode = true;
        if (Input.GetKeyDown(KeyCode.N)) faceMode = false;
        //Jaw extending
        if(faceMode)
        {
            if (jawing)
            {
                rolling.jawing = true;
            }
            if (!jawing)
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
        //if (null == sr) return "192.168.6.155:8008";
        string str = sr.ReadToEnd();
        sr.Close();
        return str;
    }
}
