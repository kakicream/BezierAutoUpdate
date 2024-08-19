using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LC_Speed : MonoBehaviour
{
    public GameObject drivingCar;
    public GameObject sideCar;
    public GameObject followCar_Left;
    public GameObject followCar_Right;

    public float leadCar_Speed;

    void Start()
    {
        leadCar_Speed = 150 * 1000 / 3600f;
    }

    void Update()
    {

    }
}
