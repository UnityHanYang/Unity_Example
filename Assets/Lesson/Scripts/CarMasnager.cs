using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMasnager : MonoBehaviour
{
    public static CarMasnager instance;
    public GameObject car;
    private bool isBattle = false;

    public bool SetState { get; set; }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        car.AddComponent<CarMove>();
    }

    void Update()
    {
        
    }

    void CurrentState()
    {
       // if()
    }
}
