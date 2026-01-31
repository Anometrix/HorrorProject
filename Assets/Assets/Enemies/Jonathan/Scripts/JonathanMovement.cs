using UnityEngine;
using UnityEngine.AI;

public class JonathanMovement : MonoBehaviour
{
    #region Variables
    // Components
    private Rigidbody rb;
    private NavMeshAgent agent;

    // Regular Variables
    private float currentSpeed;

    // Constants
    private const float walkSpeed = 5f; // Walk Speed here - adjust as needed
    private const float runSpeed = 10f; // Run Speed here - adjust as needed
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        currentSpeed = walkSpeed;
    }
    public void MoveTowardsTarget(Vector3 targetPosition) 
    {
        // Movement logic to move Jonathan towards the target position
    }
    public void MoveToNextPatrolPoint() 
    {
        // Movement logic to move Jonathan to the specified position
    }
    public void StopMovement() // Used for Idle state
    {
        // Logic to stop Jonathan's movement
    }
    public void SetToWalk()
    {
        currentSpeed = walkSpeed;
    }
    public void SetToRun()
    {
        currentSpeed = runSpeed;
    }
}
