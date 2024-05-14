using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponentMove : MonoBehaviour
{
    public GameObject[] car;

    void Start()
    {
        for (int i = 0; i < car.Length; i++)
        {
            car[i].AddComponent<CarMove>();
        }
    }
}
