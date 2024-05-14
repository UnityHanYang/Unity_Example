using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToHeliMove : MonoBehaviour
{
    private GameObject propeller;
    public GameObject SubProPeller;
    private float speed = 500.0f;
    Rigidbody rb;
    void Start()
    {
        propeller = this.transform.GetChild(0).gameObject;
        rb = this.GetComponent<Rigidbody>();
        SubProPeller = GameObject.Find("SubProPeller");
    }

    void Update()
    {
        InputKeyBoard();
    }

    void InputKeyBoard()
    {
        Vector3 vec = new Vector3(0, this.transform.rotation.y, 0);
        Vector3 currentVec = this.transform.position;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.useGravity = false;
            vec.y += speed * Time.deltaTime;
            SubProPeller.transform.Rotate(vec);
            propeller.transform.Rotate(vec);
            currentVec.y += 7f * Time.deltaTime;
            this.transform.position = currentVec;
        }
        else
        {
            rb.useGravity = true;
        }
        float z = Input.GetAxisRaw("Horizontal");
        float x = Input.GetAxisRaw("Vertical");

        currentVec.z += x * 6f * Time.deltaTime;
        currentVec.x += z * 6f * Time.deltaTime;
        this.transform.position = currentVec;
    }
}
