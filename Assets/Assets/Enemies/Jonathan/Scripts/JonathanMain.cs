using UnityEngine;

public class JonathanMain : MonoBehaviour
{
    // Jonathan likes bananas, just so you know. :) 
    // Yes, I did decide that on the spot.

    #region Variables
    [Header("Components")]
    public StateMachine stateMachine { get; private set; }
    public JonathanMovement jonathanMovement { get; private set; }
    [SerializeField] public NoiseSystemManager noiseSystemMan;
    [SerializeField] private Animator animator;

    // States
    public JonathanIdleState idleState;
    public JonathanPatrolState patrolState;
    public JonathanInvestigateState investigateState;
    public JonathanRushState rushState;
    #endregion
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

    void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
}
