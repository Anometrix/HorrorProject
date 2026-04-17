using UnityEngine;

public class JonathanMain : MonoBehaviour
{
    // Jonathan likes bananas, just so you know. :) 
    // Yes, I did decide that on the spot.

    #region Variables
    [Header("Components")]
    public StateMachine stateMachine { get; private set; }
    public JonathanMovement jonathanMovement { get; private set; }
    [SerializeField] private Animator animator;

    // States
    public JonathanIdleState idleState;
    public JonathanPatrolState patrolState;
    public JonathanInvestigateState investigateState;
    public JonathanRushState rushState;

    [Header("Regular Variables")]
    [Range(0f, 25f)]
    [Tooltip("The minimum sound required for Jonathan to investigate noise.")]
    public float withinNoiseThreshold = 15f;
    [Range(26f, 50f)]
    [Tooltip("The minimum sound required for Jonathan to rush towards noise.")]
    public float pastNoiseThreshold = 26f;
    private float soundCheckTimer = 0f;
    public HeardSound currentSoundHeard;
    public HeardSound lockedSound;
    #endregion

    #region Awake/Start
    private void Awake()
    {
        stateMachine = new StateMachine();
        jonathanMovement = GetComponent<JonathanMovement>();
        animator = GetComponent<Animator>();

        idleState = new JonathanIdleState(this, stateMachine, animator, "Idle");
        patrolState = new JonathanPatrolState(this, stateMachine, animator, "Walk");
        investigateState = new JonathanInvestigateState(this, stateMachine, animator, "Walk");
        rushState = new JonathanRushState(this, stateMachine, animator, "Run");
    }
    void Start()
    {
        stateMachine.InitializeStateMachine(patrolState);
    }
    #endregion

    #region Update/FixedUpdate
    void Update()
    {
        stateMachine.currentState.LogicUpdate();

        if (soundCheckTimer <= 0f)
        {
            soundCheckTimer = 0.5f; // Check for sounds every 0.5 seconds
            currentSoundHeard = NoiseSystemManager.manInstance.GetLoudestSound(transform.position); // Check for sounds and react accordingly in the current state
        }
        else
        {
            soundCheckTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
    #endregion
}