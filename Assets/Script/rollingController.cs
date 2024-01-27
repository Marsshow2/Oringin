using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollingController : MonoBehaviour
{
    public Rolling rolling;
    // Update is called once per frame
    void Update()
    {
        //Jaw extending
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rolling.jawing = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rolling.jawing = false;
        }
    }
}
