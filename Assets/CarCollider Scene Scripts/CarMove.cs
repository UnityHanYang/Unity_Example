using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    private float speed = 5f;
    private float frotate = 160f;
    private bool isCollider;
    [SerializeField] private GameObject[] tires;
    private Rigidbody rb;
    Quaternion q;
    void Start()
    {
        tires = GameObject.FindGameObjectsWithTag("Tire");
        isCollider = false;
        rb = this.GetComponent<Rigidbody>();
        q = this.transform.rotation;
        q.y = this.transform.localEulerAngles.y;
    }

    private void FixedUpdate()
    {
        if (!isCollider)
        {
            CarForwardMove();
            TireRotate();
        }
    }

    void CarForwardMove()
    {
        Vector3 vec = this.transform.position;
        this.transform.localRotation = q;
        if (Mathf.Approximately(Mathf.Floor(Mathf.Abs(this.transform.localEulerAngles.y)), 0.0000f))
        {
            vec.x += speed * Time.deltaTime;
        }
        else if (Mathf.Approximately(Mathf.Floor(this.transform.localEulerAngles.y), 180f))
        {
            vec.x -= speed * Time.deltaTime;
        }
        this.transform.position = vec;
    }

    void TireRotate()
    {
        for(int i = 0;i<tires.Length; i++)  
        {
            Vector3 vec = new Vector3(this.transform.rotation.x, 0, 0);
            vec.y -= frotate * Time.deltaTime;
            tires[i].transform.Rotate(vec);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.tag.Equals("Ground"))
        {
            Vector3 vec = this.transform.position;
            rb.AddForce(vec, ForceMode.Impulse);
        }
    }
}
