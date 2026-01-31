using UnityEngine;

public class JonathanMain : MonoBehaviour
{
    // Jonathan likes bananas, just so you know. :) 
    // Yes, I did decide that on the spot.

    #region Variables
    public StateMachine stateMachine { get; private set; }
    public JonathanMovement jonathanMovement { get; private set; }

    [SerializeField] public NoiseSystemManager noiseSystemMan; 

    public JonathanIdleState idleState;
    public JonathanPatrolState patrolState;
    public JonathanInvestigateState investigateState;
    public JonathanRushState rushState;
    #endregion
    void Start()
    {
        stateMachine.InitializeStateMachine(idleState);
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
