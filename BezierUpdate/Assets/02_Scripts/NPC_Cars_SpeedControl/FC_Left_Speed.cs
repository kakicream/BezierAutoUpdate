using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC_Left_Speed : MonoBehaviour
{
    public GameObject drivingCar;
    public GameObject leadCar;
    public GameObject sideCar;
    public GameObject followCar_Right;

    public float followCar_Left_Speed;

    void Start()
    {
        followCar_Left_Speed = 120 * 1000 / 3600f;
    }

    void Update()
    {

    }
}
