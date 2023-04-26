using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform obstacle;
    public float rotateSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        obstacle.Rotate(0, 0, rotateSpeed*Time.fixedDeltaTime);
    }
}
