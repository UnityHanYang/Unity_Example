using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMove : MonoBehaviour
{
    private float speed = 3.0f;
    void Update()
    {
        this.transform.Rotate(Vector3.up * 90f * Time.deltaTime);
    }
}
