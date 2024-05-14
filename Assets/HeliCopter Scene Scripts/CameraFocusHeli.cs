using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusHeli : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vecO = target.transform.position;
        Vector3 vec = target.transform.position;

        vecO.y += 3f;
        vecO.z -= 5f;
        this.transform.position = vecO;
        this.transform.LookAt(vec);
    }
}
