using UnityEngine;

public class JonathanIdleState : JonathanState
{
    // What happens in this state:
    // Jonathan stands still for a brief moment : This is more of a transition state.
    // Gives player a very small time window to move.
    // States Rush and Investigate switch to this state when they finish their actions.
    // Patrol switches to this state at specified patrol points.

    public JonathanIdleState(JonathanMain jonathanMain, StateMachine sm, Animator animationController, string animationName) : base(jonathanMain, sm, animationController, animationName)
    {
    }
}
