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
    public override void TransitionChecks()
    {
        base.TransitionChecks();

        #region Safety Checks
        if (jonathanMain.lockedSound.heardIntensity <= 0f) // Safety check to prevent bugs --------- BAD IN HERE
        {
            jonathanMain.stateMachine.ChangeState(jonathanMain.patrolState);
            return;
        }
        #endregion

        // Gotta add conditions to switch to patrol, investigate, or rush
    }
    public override void Enter()
    {
        base.Enter();
        jonathanMain.jonathanMovement.StopMovement();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}