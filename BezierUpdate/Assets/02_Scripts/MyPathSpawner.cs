using System.Collections;
using System.Collections.Generic;
using PathCreation;
using PathCreation.Examples;
using UnityEngine;

public class MyPathSpawner : MonoBehaviour
{

    public PathCreator[] pathPrefabs;
    public Transform[] spawnPoints;

    PathCreator path_LC;
    PathCreator path_SC;
    PathCreator path_FC_Left;
    PathCreator path_FC_Right;

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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1)) // Accident 1
        {
            BezierPath bp_LC = path_LC.bezierPath;
            
            bp_LC.SetPoint(3, new Vector3(3, 0, 100));
            bp_LC.SetPoint(6, new Vector3(-10, 0, 215));

            path_LC.bezierPath = bp_LC;           
        }
        if (Input.GetKeyDown(KeyCode.Keypad2)) // Accident 2
        {

        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {

        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {

        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {

        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {

        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {

        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {

        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {

        }
    }
}

