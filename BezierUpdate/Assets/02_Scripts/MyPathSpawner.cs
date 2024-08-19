// using System.Collections;
// using System.Collections.Generic;
// using PathCreation;
// using PathCreation.Examples;
// using UnityEngine;

// public class MyPathSpawner : MonoBehaviour
// {

//     public PathCreator[] pathPrefabs;
//     public Transform[] spawnPoints;

//     PathCreator path_LC;
//     PathCreator path_SC;
//     PathCreator path_FC_Left;
//     PathCreator path_FC_Right;

//     void Start()
//     {
//         foreach (Transform t in spawnPoints)
//         {
//             path_LC = Instantiate(pathPrefabs[0], t.position, t.rotation);
//             path_LC.transform.parent = t;

//             path_SC = Instantiate(pathPrefabs[1], t.position, t.rotation);
//             path_SC.transform.parent = t;

//             path_FC_Left = Instantiate(pathPrefabs[2], t.position, t.rotation);
//             path_FC_Left.transform.parent = t;

//             path_FC_Right = Instantiate(pathPrefabs[3], t.position, t.rotation);
//             path_FC_Right.transform.parent = t;
//         }
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Keypad1)) // Accident 1
//         {
//             BezierPath bp_LC = path_LC.bezierPath;
//             bp_LC.SetPoint(3, new Vector3(3, 0, 100));
//             bp_LC.SetPoint(6, new Vector3(-10, 0, 215));
//             path_LC.bezierPath = bp_LC;           

//             BezierPath bp_SC = path_SC.bezierPath;
//             bp_SC.SetPoint(3, new Vector3(5, 0, 100));
//             bp_SC.SetPoint(6,new Vector3(3, 0, 150));
//             path_SC.bezierPath = bp_SC;

//             BezierPath bp_FC_Left = path_FC_Left.bezierPath;
//             bp_FC_Left.SetPoint(3, new Vector3(7, 0, 240));
//             bp_FC_Left.SetPoint(6, new Vector3(-4, 0, 320));
//             path_FC_Left.bezierPath = bp_FC_Left;

//             BezierPath bp_FC_Right = path_FC_Right.bezierPath;
//             path_FC_Right.SetPoint(3, new Vector3(9, 0, 190));
//             path_FC_Right.SetPoint(6, new Vector3(-10,0, 350));
//             path_FC_Right.bezierPath = bp_FC_Right;

//         }
//         if (Input.GetKeyDown(KeyCode.Keypad2)) // Accident 2
//         {

//         }
//         if (Input.GetKeyDown(KeyCode.Keypad3))
//         {

//         }
//         if (Input.GetKeyDown(KeyCode.Keypad4))
//         {

//         }
//         if (Input.GetKeyDown(KeyCode.Keypad5))
//         {

//         }
//         if (Input.GetKeyDown(KeyCode.Keypad6))
//         {

//         }
//         if (Input.GetKeyDown(KeyCode.Keypad7))
//         {

//         }
//         if (Input.GetKeyDown(KeyCode.Keypad8))
//         {

//         }
//         if (Input.GetKeyDown(KeyCode.Keypad9))
//         {

//         }
//     }
// }

using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class MyPathSpawner : MonoBehaviour
{
    public PathCreator[] pathPrefabs;
    public Transform[] spawnPoints;

    private Dictionary<int, Vector3[]> accidentSettings;

    private PathCreator path_LC;
    private PathCreator path_SC;
    private PathCreator path_FC_Left;
    private PathCreator path_FC_Right;

    void Start()
    {
        foreach (Transform t in spawnPoints)
        {
            path_LC = Instantiate(pathPrefabs[0], t.position, t.rotation);
            path_LC.transform.parent = t;

            path_SC = Instantiate(pathPrefabs[1], t.position, t.rotation);
            path_SC.transform.parent = t;

            path_FC_Left = Instantiate(pathPrefabs[2], t.position, t.rotation);
            path_FC_Left.transform.parent = t;

            path_FC_Right = Instantiate(pathPrefabs[3], t.position, t.rotation);
            path_FC_Right.transform.parent = t;
        }

        // 각 사고 설정을 미리 매핑
        accidentSettings = new Dictionary<int, Vector3[]>
    {
        { 1, new[] {
        new Vector3(3, 0, 100), new Vector3(-10, 0, 215),  // LC
        new Vector3(5, 0, 100), new Vector3(3, 0, 150),   // SC
        new Vector3(7, 0, 240), new Vector3(-4, 0, 320),  // FC Left
        new Vector3(9, 0, 190), new Vector3(-10, 0, 350)  // FC Right
    }},
    {
    2, new[] {
        new Vector3(2, 0, 90), new Vector3(-8, 0, 210),   // LC
        new Vector3(6, 0, 105), new Vector3(4, 0, 155),  // SC
        new Vector3(8, 0, 235), new Vector3(-5, 0, 315), // FC Left
        new Vector3(10, 0, 195), new Vector3(-9, 0, 345) // FC Right
    }},
    {
    3, new[] {
        new Vector3(1, 0, 85), new Vector3(-7, 0, 200),   // LC
        new Vector3(7, 0, 110), new Vector3(2, 0, 145),  // SC
        new Vector3(6, 0, 245), new Vector3(-3, 0, 310), // FC Left
        new Vector3(11, 0, 185), new Vector3(-11, 0, 340) // FC Right
    }},
    {
    4, new[] {
        new Vector3(4, 0, 95), new Vector3(-9, 0, 220),   // LC
        new Vector3(5, 0, 115), new Vector3(5, 0, 160),  // SC
        new Vector3(9, 0, 255), new Vector3(-6, 0, 325), // FC Left
        new Vector3(8, 0, 205), new Vector3(-12, 0, 360) // FC Right
    }},
    {
    5, new[] {
        new Vector3(0, 0, 80), new Vector3(-11, 0, 190),  // LC
        new Vector3(4, 0, 120), new Vector3(3, 0, 140),  // SC
        new Vector3(7, 0, 230), new Vector3(-2, 0, 300), // FC Left
        new Vector3(10, 0, 180), new Vector3(-8, 0, 330) // FC Right
    }},
    {
    6, new[] {
        new Vector3(5, 0, 100), new Vector3(-6, 0, 210),  // LC
        new Vector3(8, 0, 125), new Vector3(2, 0, 155),  // SC
        new Vector3(10, 0, 240), new Vector3(-4, 0, 310), // FC Left
        new Vector3(9, 0, 195), new Vector3(-7, 0, 340) // FC Right
    }},
    {
    7, new[] {
        new Vector3(2, 0, 95), new Vector3(-9, 0, 215),   // LC
        new Vector3(6, 0, 130), new Vector3(1, 0, 150),  // SC
        new Vector3(8, 0, 250), new Vector3(-3, 0, 320), // FC Left
        new Vector3(11, 0, 200), new Vector3(-10, 0, 350) // FC Right
    }},
    {
    8, new[] {
        new Vector3(3, 0, 85), new Vector3(-7, 0, 205),   // LC
        new Vector3(5, 0, 115), new Vector3(4, 0, 145),  // SC
        new Vector3(9, 0, 235), new Vector3(-5, 0, 310), // FC Left
        new Vector3(10, 0, 190), new Vector3(-11, 0, 340) // FC Right
    }},
    {
    9, new[] {
        new Vector3(1, 0, 90), new Vector3(-8, 0, 225),   // LC
        new Vector3(7, 0, 100), new Vector3(2, 0, 140),  // SC
        new Vector3(6, 0, 245), new Vector3(-2, 0, 330), // FC Left
        new Vector3(12, 0, 180), new Vector3(-9, 0, 360) // FC Right
    }}
};
    }

    void Update()
    {
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0 + i))
            {
                ApplyAccidentSettings(i);
            }
        }
    }

    void ApplyAccidentSettings(int keypadNumber)
    {
        if (accidentSettings.ContainsKey(keypadNumber))
        {
            var settings = accidentSettings[keypadNumber];

            // LC 설정
            SetBezierPathPoints(path_LC, settings[0], settings[1]);
            // SC 설정
            SetBezierPathPoints(path_SC, settings[2], settings[3]);
            // FC Left 설정
            SetBezierPathPoints(path_FC_Left, settings[4], settings[5]);
            // FC Right 설정
            SetBezierPathPoints(path_FC_Right, settings[6], settings[7]);
        }
    }

    void SetBezierPathPoints(PathCreator path, Vector3 point3, Vector3 point6)
    {
        var bezierPath = path.bezierPath;
        bezierPath.SetPoint(3, point3);
        bezierPath.SetPoint(6, point6);
        path.bezierPath = bezierPath;
    }

    

}
