using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTrace : MonoBehaviour
{
    public Sprite[] pic;
    public GameObject player;

    private void Update()
    {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;

        if (player.GetComponent<Rolling>().jawing)
            ChangeFace(1);
        else
            ChangeFace(0);
    }

    public void ChangeFace(int n)
    {
        GetComponent<SpriteRenderer>().sprite = pic[n];
    }
}
