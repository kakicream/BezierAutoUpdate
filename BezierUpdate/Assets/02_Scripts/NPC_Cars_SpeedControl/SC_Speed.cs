using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Speed : MonoBehaviour
{
    public GameObject drivingCar;
    public GameObject leadCar;
    public GameObject followCar_Left;
    public GameObject followCar_Right;

    public float sideCar_Speed;

    void Start()
    {
        sideCar_Speed = 170 * 1000 / 3600f;
    }

    void Update()
    {

    }
}
