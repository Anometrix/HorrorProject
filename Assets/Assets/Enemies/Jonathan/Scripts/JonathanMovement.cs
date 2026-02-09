using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class JonathanMovement : MonoBehaviour
{
    #region Variables
    [Header("Components")]
    private Rigidbody rb;
    private NavMeshAgent agent;
    [SerializeField] private Transform[] patrolPoints;

    [Header("Settings/Regular Variables")]
    [SerializeField] private float patrolWaitTime = 2f;
    [SerializeField] private float stoppingDistance = 0.5f;
    private int currentPatrolIndex;
    private bool isWaiting;

    // Constants
    private const float walkSpeed = 5f; // Walk Speed here - adjust as needed
    private const float runSpeed = 10f; // Run Speed here - adjust as needed
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    #region Investigate/Rush Movement Functions
    public void MoveTowardsTarget(Vector3 targetPosition) // Used for Investigate and Rush states
    {
        agent.SetDestination(targetPosition);
    }
    #endregion

    #region Patrol State Functions
    public void Patrol()
    {
        if (isWaiting) return;
        if (!agent.pathPending && agent.remainingDistance <= stoppingDistance)
        {
            StartCoroutine(WaitAtPatrolPoint());
        }
    }
    private IEnumerator WaitAtPatrolPoint()
    {
        isWaiting = true;
        agent.isStopped = true;

        yield return new WaitForSeconds(patrolWaitTime);

        isWaiting = false;
        MoveToNextPatrolPoint();
        isWaiting = false;
    }
    private void MoveToNextPatrolPoint() 
    {
        agent.isStopped = false;
        if (patrolPoints.Length == 0) return; // No patrol points = do nothing

        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length; // Increment and loop patrol index
    }
    #endregion

    #region Pure Movement Setters - No Logic
    public void StopMovement()
    {
        agent.isStopped = true;
    }
    public void SetToWalk()
    {
        agent.speed = walkSpeed;
    }
    public void SetToRun()
    {
        agent.speed = runSpeed;
    }
    #endregion
}