using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.UIElements;

public class MyPathSpawner : MonoBehaviour
{
    public PathCreator[] pathPrefabs;
    public Transform[] spawnPoints;

    private Dictionary<int, Vector3[]> accidentSettings;

    private PathCreator path_LC;
    private Vector3 lc_Point0, lc_Point3, lc_Point6, lc_Point9;

    private PathCreator path_SC;
    private Vector3 sc_Point0, sc_Point3, sc_Point6, sc_Point9;

    private PathCreator path_FC_Left;
    private Vector3 fc_Left_Point0, fc_Left_Point3, fc_Left_Point6, fc_Left_Point9;

    private PathCreator path_FC_Right;
    private Vector3 fc_Right_Point0, fc_Right_Point3, fc_Right_Point6, fc_Right_Point9;

    public Vector3 curveOffset = new Vector3(0, 0, 20);
    public float randomZOffset;

    public bool dc_Cruise_Lane1;

    public GameObject leadCar;
    MyPathFollower mpf_LeadCar;
    public GameObject sideCar;
    MyPathFollower mpf_SideCar;
    public GameObject followCar_Left;
    MyPathFollower mpf_FollowCar_Left;
    public GameObject followCar_Right;
    MyPathFollower mpf_FollowCar_Right;

    void Start()
    {
        mpf_LeadCar = leadCar.GetComponent<MyPathFollower>();
        mpf_SideCar = sideCar.GetComponent<MyPathFollower>();
        mpf_FollowCar_Left = followCar_Left.GetComponent<MyPathFollower>();
        mpf_FollowCar_Right = followCar_Right.GetComponent<MyPathFollower>();

        dc_Cruise_Lane1 = false;
        foreach (Transform t in spawnPoints)
        {
            path_LC = Instantiate(pathPrefabs[0], t.position, t.rotation);
            path_LC.transform.parent = t;
            mpf_LeadCar.pathCreator = path_LC;

            path_SC = Instantiate(pathPrefabs[1], t.position, t.rotation);
            path_SC.transform.parent = t;
            mpf_SideCar.pathCreator = path_SC;

            path_FC_Left = Instantiate(pathPrefabs[2], t.position, t.rotation);
            path_FC_Left.transform.parent = t;
            mpf_FollowCar_Left.pathCreator = path_FC_Left;

            path_FC_Right = Instantiate(pathPrefabs[3], t.position, t.rotation);
            path_FC_Right.transform.parent = t;
            mpf_FollowCar_Right.pathCreator = path_FC_Right;
        }
        ApplyAccidentSettings(1, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dc_Cruise_Lane1 = !dc_Cruise_Lane1;
        }
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0 + i))
            {
                float zOffset = Random.Range(0f, 100f);
                randomZOffset = zOffset;
                ApplyAccidentSettings(i, zOffset);
            }
        }
    }

    void ApplyAccidentSettings(int keypadNumber, float zOffset)
    {
        if (dc_Cruise_Lane1 == false) // DC : Cruise in Lane 2
        {
            switch (keypadNumber)
            {
                case 1:
                case 2:
                case 3:
                default:
                    lc_Point0 = new Vector3(0, 0, 100);
                    lc_Point3 = new Vector3(0, 0, 200);
                    lc_Point6 = new Vector3(0, 0, 300);
                    lc_Point9 = new Vector3(0, 0, 500);

                    sc_Point0 = new Vector3(-6, 0, 0);
                    sc_Point3 = new Vector3(-6, 0, 200);
                    sc_Point6 = new Vector3(-6, 0, 300);
                    sc_Point9 = new Vector3(-6, 0, 500);

                    fc_Left_Point0 = new Vector3(-6, 0, 0);
                    fc_Left_Point3 = new Vector3(-6, 0, 200);
                    fc_Left_Point6 = new Vector3(-6, 0, 300);
                    fc_Left_Point9 = new Vector3(-6, 0, 500);

                    fc_Right_Point0 = new Vector3(0, 0, 0);
                    fc_Right_Point3 = new Vector3(0, 0, 200);
                    fc_Right_Point6 = new Vector3(0, 0, 300);
                    fc_Right_Point9 = new Vector3(0, 0, 500);
                    break;
                case 4:
                case 5:
                case 6:
                    lc_Point0 = new Vector3(0, 0, 100);
                    lc_Point3 = new Vector3(0, 0, 200);
                    lc_Point6 = new Vector3(-6, 0, 300);
                    lc_Point9 = new Vector3(-6, 0, 500);

                    sc_Point0 = new Vector3(-6, 0, 0);
                    sc_Point3 = new Vector3(-6, 0, 200);
                    sc_Point6 = new Vector3(-6, 0, 300);
                    sc_Point9 = new Vector3(-6, 0, 500);

                    fc_Left_Point0 = new Vector3(-6, 0, 0);
                    fc_Left_Point3 = new Vector3(-6, 0, 200);
                    fc_Left_Point6 = new Vector3(-6, 0, 300);
                    fc_Left_Point9 = new Vector3(-6, 0, 500);

                    fc_Right_Point0 = new Vector3(0, 0, 0);
                    fc_Right_Point3 = new Vector3(0, 0, 200);
                    fc_Right_Point6 = new Vector3(0, 0, 300);
                    fc_Right_Point9 = new Vector3(0, 0, 500);
                    break;
                case 7:
                case 8:
                case 9:
                    lc_Point0 = new Vector3(0, 0, 100);
                    lc_Point3 = new Vector3(0, 0, 200);
                    lc_Point6 = new Vector3(0, 0, 300);
                    lc_Point9 = new Vector3(0, 0, 500);

                    sc_Point0 = new Vector3(-6, 0, 0);
                    sc_Point3 = new Vector3(-6, 0, 200);
                    sc_Point6 = new Vector3(0, 0, 300);
                    sc_Point9 = new Vector3(0, 0, 500);

                    fc_Left_Point0 = new Vector3(-6, 0, 0);
                    fc_Left_Point3 = new Vector3(-6, 0, 200);
                    fc_Left_Point6 = new Vector3(-6, 0, 300);
                    fc_Left_Point9 = new Vector3(-6, 0, 500);

                    fc_Right_Point0 = new Vector3(0, 0, 0);
                    fc_Right_Point3 = new Vector3(0, 0, 200);
                    fc_Right_Point6 = new Vector3(0, 0, 300);
                    fc_Right_Point9 = new Vector3(0, 0, 500);
                    break;
            }
        }
        else // DC : Cruise in Lane 1
        {
            switch (keypadNumber)
            {
                case 1:
                case 2:
                case 3:
                default:
                    lc_Point0 = new Vector3(-6, 0, 100);
                    lc_Point3 = new Vector3(-6, 0, 200);
                    lc_Point6 = new Vector3(-6, 0, 300);
                    lc_Point9 = new Vector3(-6, 0, 500);

                    sc_Point0 = new Vector3(0, 0, 0);
                    sc_Point3 = new Vector3(0, 0, 200);
                    sc_Point6 = new Vector3(0, 0, 300);
                    sc_Point9 = new Vector3(0, 0, 500);

                    fc_Left_Point0 = new Vector3(0, 0, 0);
                    fc_Left_Point3 = new Vector3(0, 0, 200);
                    fc_Left_Point6 = new Vector3(0, 0, 300);
                    fc_Left_Point9 = new Vector3(0, 0, 500);

                    fc_Right_Point0 = new Vector3(-6, 0, 0);
                    fc_Right_Point3 = new Vector3(-6, 0, 200);
                    fc_Right_Point6 = new Vector3(-6, 0, 300);
                    fc_Right_Point9 = new Vector3(-6, 0, 500);
                    break;
                case 4:
                case 5:
                case 6:
                    lc_Point0 = new Vector3(-6, 0, 100);
                    lc_Point3 = new Vector3(-6, 0, 200);
                    lc_Point6 = new Vector3(0, 0, 300);
                    lc_Point9 = new Vector3(0, 0, 500);

                    sc_Point0 = new Vector3(0, 0, 0);
                    sc_Point3 = new Vector3(0, 0, 200);
                    sc_Point6 = new Vector3(0, 0, 300);
                    sc_Point9 = new Vector3(0, 0, 500);

                    fc_Left_Point0 = new Vector3(0, 0, 0);
                    fc_Left_Point3 = new Vector3(0, 0, 200);
                    fc_Left_Point6 = new Vector3(0, 0, 300);
                    fc_Left_Point9 = new Vector3(0, 0, 500);

                    fc_Right_Point0 = new Vector3(-6, 0, 0);
                    fc_Right_Point3 = new Vector3(-6, 0, 200);
                    fc_Right_Point6 = new Vector3(-6, 0, 300);
                    fc_Right_Point9 = new Vector3(-6, 0, 500);
                    break;
                case 7:
                case 8:
                case 9:
                    lc_Point0 = new Vector3(-6, 0, 100);
                    lc_Point3 = new Vector3(-6, 0, 200);
                    lc_Point6 = new Vector3(-6, 0, 300);
                    lc_Point9 = new Vector3(-6, 0, 500);

                    sc_Point0 = new Vector3(0, 0, 0);
                    sc_Point3 = new Vector3(0, 0, 200);
                    sc_Point6 = new Vector3(-6, 0, 300);
                    sc_Point9 = new Vector3(-6, 0, 500);

                    fc_Left_Point0 = new Vector3(0, 0, 0);
                    fc_Left_Point3 = new Vector3(0, 0, 200);
                    fc_Left_Point6 = new Vector3(0, 0, 300);
                    fc_Left_Point9 = new Vector3(0, 0, 500);

                    fc_Right_Point0 = new Vector3(-6, 0, 0);
                    fc_Right_Point3 = new Vector3(-6, 0, 200);
                    fc_Right_Point6 = new Vector3(-6, 0, 300);
                    fc_Right_Point9 = new Vector3(-6, 0, 500);
                    break;
            }
        }
        SetBezierPathPoints(path_LC,
                            lc_Point0, lc_Point0 + curveOffset,
                            lc_Point3 - curveOffset, lc_Point3, lc_Point3 + curveOffset,
                            lc_Point6 - curveOffset, lc_Point6, lc_Point6 + curveOffset,
                            lc_Point9 - curveOffset, lc_Point9);

        SetBezierPathPoints(path_SC,
                            sc_Point0, sc_Point0 + curveOffset,
                            sc_Point3 - curveOffset, sc_Point3, sc_Point3 + curveOffset,
                            sc_Point6 - curveOffset, sc_Point6, sc_Point6 + curveOffset,
                            sc_Point9 - curveOffset, sc_Point9);
        SetBezierPathPoints(path_FC_Left,
                            fc_Left_Point0, fc_Left_Point0 + curveOffset,
                            fc_Left_Point3 - curveOffset, fc_Left_Point3, fc_Left_Point3 + curveOffset,
                            fc_Left_Point6 - curveOffset, fc_Left_Point6, fc_Left_Point6 + curveOffset,
                            fc_Left_Point9 - curveOffset, fc_Left_Point9);
        SetBezierPathPoints(path_FC_Right,
                            fc_Right_Point0, fc_Right_Point0 + curveOffset,
                            fc_Right_Point3 - curveOffset, fc_Right_Point3, fc_Right_Point3 + curveOffset,
                            fc_Right_Point6 - curveOffset, fc_Right_Point6, fc_Right_Point6 + curveOffset,
                            fc_Right_Point9 - curveOffset, fc_Right_Point9);
    }

    void SetBezierPathPoints(PathCreator path, Vector3 point0, Vector3 point1, Vector3 point2, Vector3 point3, Vector3 point4, Vector3 point5, Vector3 point6, Vector3 point7, Vector3 point8, Vector3 point9)
    {
        var bezierPath = path.bezierPath;
        bezierPath.SetPoint(0, point0);
        bezierPath.SetPoint(1, point1);
        bezierPath.SetPoint(2, point2);
        bezierPath.SetPoint(3, point3);
        bezierPath.SetPoint(4, point4);
        bezierPath.SetPoint(5, point5);
        bezierPath.SetPoint(6, point6);
        bezierPath.SetPoint(7, point7);
        bezierPath.SetPoint(8, point8);
        bezierPath.SetPoint(9, point9);
        path.bezierPath = bezierPath;
    }
}




/*
// 각 사고 설정을 미리 매핑
        accidentSettings = new Dictionary<int, Vector3[]>
    {
        { 1, new[] {
        new Vector3(0, 0, 200), new Vector3(0, 0, 300),  // LC
        new Vector3(-6, 0, 200), new Vector3(0, 0, 250),   // SC
        new Vector3(-6, 0, 200), new Vector3(-6, 0, 300),  // FC Left
        new Vector3(0, 0, 200), new Vector3(0, 0, 300)  // FC Right
    }},
    {
    2, new[] {
        new Vector3(0, 0, 200), new Vector3(0, 0, 300),  // LC
        new Vector3(6, 0, 105), new Vector3(4, 0, 155),  // SC
        new Vector3(8, 0, 235), new Vector3(-5, 0, 315), // FC Left
        new Vector3(10, 0, 195), new Vector3(-9, 0, 345) // FC Right
    }},
    {
    3, new[] {
        new Vector3(0, 0, 200), new Vector3(0, 0, 300),  // LC
        new Vector3(7, 0, 110), new Vector3(2, 0, 145),  // SC
        new Vector3(6, 0, 245), new Vector3(-3, 0, 310), // FC Left
        new Vector3(11, 0, 185), new Vector3(-11, 0, 340) // FC Right
    }},
    {
    4, new[] {
        new Vector3(0, 0, 200), new Vector3(0, 0, 300),  // LC
        new Vector3(5, 0, 115), new Vector3(5, 0, 160),  // SC
        new Vector3(9, 0, 255), new Vector3(-6, 0, 325), // FC Left
        new Vector3(8, 0, 205), new Vector3(-12, 0, 360) // FC Right
    }},
    {
    5, new[] {
        new Vector3(0, 0, 200), new Vector3(0, 0, 300),  // LC
        new Vector3(4, 0, 120), new Vector3(3, 0, 140),  // SC
        new Vector3(7, 0, 230), new Vector3(-2, 0, 300), // FC Left
        new Vector3(10, 0, 180), new Vector3(-8, 0, 330) // FC Right
    }},
    {
    6, new[] {
        new Vector3(0, 0, 200), new Vector3(0, 0, 300),  // LC
        new Vector3(8, 0, 125), new Vector3(2, 0, 155),  // SC
        new Vector3(10, 0, 240), new Vector3(-4, 0, 310), // FC Left
        new Vector3(9, 0, 195), new Vector3(-7, 0, 340) // FC Right
    }},
    {
    7, new[] {
        new Vector3(0, 0, 200), new Vector3(0, 0, 300),  // LC
        new Vector3(6, 0, 130), new Vector3(1, 0, 150),  // SC
        new Vector3(8, 0, 250), new Vector3(-3, 0, 320), // FC Left
        new Vector3(11, 0, 200), new Vector3(-10, 0, 350) // FC Right
    }},
    {
    8, new[] {
        new Vector3(0, 0, 200), new Vector3(0, 0, 300),  // LC
        new Vector3(5, 0, 115), new Vector3(4, 0, 145),  // SC
        new Vector3(9, 0, 235), new Vector3(-5, 0, 310), // FC Left
        new Vector3(10, 0, 190), new Vector3(-11, 0, 340) // FC Right
    }},
    {
    9, new[] {
        new Vector3(0, 0, 200), new Vector3(0, 0, 300),  // LC
        new Vector3(7, 0, 100), new Vector3(2, 0, 140),  // SC
        new Vector3(6, 0, 245), new Vector3(-2, 0, 330), // FC Left
        new Vector3(12, 0, 180), new Vector3(-9, 0, 360) // FC Right
    }}
};
*/