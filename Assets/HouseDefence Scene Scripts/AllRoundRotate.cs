using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllRoundRotate : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = go.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(distance);
    }
}
