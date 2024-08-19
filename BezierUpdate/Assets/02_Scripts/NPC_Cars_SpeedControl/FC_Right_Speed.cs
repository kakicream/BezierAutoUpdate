using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC_Right_Speed : MonoBehaviour
{
    public GameObject drivingCar;
    public GameObject leadCar;
    public GameObject sideCar;
    public GameObject followCar_Left;

    public float followCar_Right_Speed;

    // public GameObject accidentScenarioController;
    // AccidentScenarioController asc;

    void Start()
    {
        // asc = accidentScenarioController.GetComponent<AccidentScenarioController>();
        followCar_Right_Speed = 90 * 1000 / 3600f;
    }

    void Update()
    {

    }
}
