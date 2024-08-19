using UnityEngine;
using PathCreation;

// Moves along a path at constant speed.
// Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
public class MyPathFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    float distanceTravelled;

    Vector3 initPos;
    Quaternion initRot;

    bool canDriveNow = false;

    NPC_Car_SpeedController npc_Car_SpeedController;

    void Start()
    {
        npc_Car_SpeedController = GetComponent<NPC_Car_SpeedController>();
        canDriveNow = false;
        initPos = transform.position;
        initRot = transform.rotation;
        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
    }

    void Update()
    {
        speed = npc_Car_SpeedController.speed;
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0 + i))
            {
                if (canDriveNow == true)
                {
                    ResetPosition();
                }
                else
                {
                    canDriveNow = true;
                }
            }
        }
        if (pathCreator != null && canDriveNow == true)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }
    }

    void ResetPosition()
    {
        canDriveNow = false;
        transform.position = initPos;
        transform.rotation = initRot;
        distanceTravelled = 0;
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}
