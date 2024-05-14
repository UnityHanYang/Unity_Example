using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        Vector3 vec = target.transform.position;
        vec.y += 3f;
        vec.x -= 5f;
        this.transform.position = vec;
        this.transform.LookAt(target.transform.position);
        //this.transform.Rotate(new Vector3(-90, 70, -60));
    }
}
