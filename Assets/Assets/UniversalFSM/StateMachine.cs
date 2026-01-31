using UnityEngine;

public class StateMachine
{
    #region Variables -- Just one, really.
    public State currentState { get; private set; }
    #endregion
    public void InitializeStateMachine(State startingState) // Would be called in the Start method of the MonoBehaviour that uses this StateMachine
    {
        currentState = startingState;
        currentState.Enter();
    }
    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
