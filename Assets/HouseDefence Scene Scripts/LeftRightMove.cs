using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMove : MonoBehaviour
{
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 vec = this.transform.position;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.PingPong(Time.time * 7f, 44));
    }
}
    