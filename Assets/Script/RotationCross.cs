using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCross : MonoBehaviour
{
    public float RotationSpeed=0.05f;

    void FixedUpdate()
    {
        transform.Rotate(0, 0, -RotationSpeed);
    }
}
