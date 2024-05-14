using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputToMoveBattleMobile : MonoBehaviour
{
    private GameObject[] tires;
    public GameObject horizontalRotateGob;
    public GameObject vecticalRotateGob;
    private float frotate = 160f;
    private bool isEnter;
    private bool isEnter2;
    private bool isAdd;
    Quaternion[] currentVec = new Quaternion[4];
    void Start()
    {
        tires = GameObject.FindGameObjectsWithTag("Tire");
        isEnter = false;
        isEnter2 = false;
        isAdd = false;
        for(int i = 0; i < tires.Length; i++)
        {
            currentVec[i] = tires[i].transform.localRotation;
        }
    }
    void Update()
    {
        Move();
    }

    void TireHorizontalRotate(float num)
    {
        if (!isEnter)
        {
            Quaternion q = tires[0].transform.localRotation;
            for (int i = 0; i < tires.Length; i++)
            {
                switch (i)
                {
                    case 0:
                    case 3:
                        q.x = 65f;
                        break;
                    case 1:
                        q.x = 110f;
                        break;
                    case 2:
                        q.x = 70f;
                        break;
                }
                q.y = 100f;
                q.z = 0f;
                tires[i].transform.localRotation = q;
            }
            isEnter = true;
        }
        for (int i = 0; i < tires.Length; i++)
        {
            Vector3 vec = new Vector3(this.transform.localRotation.x, 0, 0);
            vec.y += num * frotate * Time.deltaTime;
            vec.x = 0f;
            vec.z = 0f;
            tires[i].transform.Rotate(vec);

        }
    }


    void TireVerticalRotate(float num)
    {
        if (!isEnter2)
        {
            for (int i = 0; i < tires.Length; i++)
            {
                tires[i].transform.localRotation = currentVec[i];
            }
            isEnter2 = true;
        }
        for (int i = 0; i < tires.Length; i++)
        {
            Vector3 vec = new Vector3(this.transform.localRotation.x, 0, 0);
            vec.y += num * frotate * Time.deltaTime;
            tires[i].transform.Rotate(vec);

        }
    }

    void CannonHorizontal()
    {
        if (CurrentStateManager.instance.state == State.battle)
        {
            if (Input.GetKey(KeyCode.J))
            {
                Vector3 vec = new Vector3(horizontalRotateGob.transform.localRotation.x, 0, 0);
                vec.y += 100.0f * Time.deltaTime;
                horizontalRotateGob.transform.Rotate(vec);
            }
            else if (Input.GetKey(KeyCode.L))
            {
                Vector3 vec = new Vector3(horizontalRotateGob.transform.localRotation.x, 0, 0);
                vec.y -= 100.0f * Time.deltaTime;
                horizontalRotateGob.transform.Rotate(vec);
            }
        }
    }

    void CannonVertical() // º¸·ù
    {
        if (CurrentStateManager.instance.state == State.battle)
        {
            if (vecticalRotateGob != null)
            {
                Vector3 vec = vecticalRotateGob.transform.localEulerAngles;
                if (Input.GetKey(KeyCode.I))
                {
                    vec.x = 0.0f;
                    vec.y = 0.0f;
                    vec.z = Mathf.Clamp(vec.z + (80.0f * Time.deltaTime), -90f, -29.206f) * Time.deltaTime;
                    vecticalRotateGob.transform.Rotate(vec);
                }
                else if (Input.GetKey(KeyCode.K))
                {
                    vec.x = 0.0f;
                    vec.y = 0.0f;
                    vec.z = Mathf.Clamp(vec.z - (80.0f * Time.deltaTime), -90f, -29.206f) * Time.deltaTime;
                    vecticalRotateGob.transform.Rotate(vec);
                }
            }
        }
    }

    void Move()
    {
        if (!isAdd)
        {
            if (GameObject.Find("HorizontalRotate"))
            {

                horizontalRotateGob = GameObject.Find("HorizontalRotate");
                isAdd = true;
            }
            if (GameObject.Find("VerticalRotate"))
            {
                vecticalRotateGob = GameObject.Find("VerticalRotate");
                isAdd = true;
            }
        }

        Vector3 currentVec = this.transform.position;

        float z = Input.GetAxisRaw("Horizontal");
        float x = Input.GetAxisRaw("Vertical");

        currentVec.z -= z * 6f * Time.deltaTime;
        currentVec.x += x * 6f * Time.deltaTime;
        if (z != 0)
        {
            isEnter2 = false;
            TireHorizontalRotate(z);
        }
        else if (x != 0)
        {
            isEnter = false;
            TireVerticalRotate(x);
        }
        this.transform.position = currentVec;
        CannonHorizontal();
        CannonVertical();
    }
}
