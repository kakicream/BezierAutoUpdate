using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class NPC_Car_SpeedController : MonoBehaviour
{
    [Header("Select Number for correct NPC Cars.\n1 : Lead Car\n2 : Side Car\n3 : Left Follow Car\n4 : Right Follow Car")]
    [Range(1, 4)] public int npcCar = 1;

    public float speed = 80 * 1000 / 3600f;

    public GameObject speedManager;
    LC_Speed lc_Speed;
    SC_Speed sc_Speed;
    FC_Left_Speed fC_Left_Speed;
    FC_Right_Speed fC_Right_Speed;

    void Start()
    {
        speed = 0;
        lc_Speed = speedManager.GetComponent<LC_Speed>();
        sc_Speed = speedManager.GetComponent<SC_Speed>();
        fC_Left_Speed = speedManager.GetComponent <FC_Left_Speed>();
        fC_Right_Speed = speedManager.GetComponent<FC_Right_Speed>();
    }

    void Update()
    {
        switch (npcCar)
        {
            case 1:
            default:
                speed = lc_Speed.leadCar_Speed;
                break;
            case 2:
                speed = sc_Speed.sideCar_Speed;
                break;
            case 3:
                speed = fC_Left_Speed.followCar_Left_Speed;
                break;
            case 4:
                speed = fC_Right_Speed.followCar_Right_Speed;
                break;
        }
    }
}
