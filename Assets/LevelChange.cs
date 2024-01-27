using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChange : MonoBehaviour
{
    public int Nextlevel;
    public Text time;
    public float calculatedTime;
    public float delayTime = 0.5f;

    private bool levelKey;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //UI here
            calculatedTime = collision.gameObject.GetComponent<Rolling>().CalculateTime();
            if(!levelKey)
                time.text = calculatedTime.ToString();

            levelKey = true;
        }
    }

    private void Update()
    {
        if(levelKey)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //Laugh anime
                Invoke("GoNextlevel", delayTime);
            }
        }
    }

    private void GoNextlevel()
    {
        SceneManager.LoadScene("Level" + Nextlevel);
    }
}
