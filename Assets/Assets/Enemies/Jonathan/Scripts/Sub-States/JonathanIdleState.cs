using UnityEngine;

public class JonathanIdleState : JonathanState
{
    // What happens in this state:
    // Jonathan stands still for a brief moment : This is more of a transition state.
    // Gives player a very small time window to move.
    // States Rush and Investigate switch to this state when they finish their actions.
    // Patrol switches to this state at specified patrol points.

    #region Variables
    float timer;
    #endregion
    public JonathanIdleState(JonathanMain jonathanMain, StateMachine sm, Animator animationController, string animationName) : base(jonathanMain, sm, animationController, animationName)
    {
    }
    public override void TransitionChecks()
    {
        base.TransitionChecks();

        if (timer <= 0f)
        {
            // Check for noise within freshold
            if (jonathanMain.currentSoundHeard.heardIntensity >= jonathanMain.pastNoiseThreshold)
            {
                jonathanMain.lockedSound = jonathanMain.currentSoundHeard;
                jonathanMain.stateMachine.ChangeState(jonathanMain.rushState);
                return;
            }
            else if (jonathanMain.currentSoundHeard.heardIntensity >= jonathanMain.withinNoiseThreshold)
            {
                jonathanMain.lockedSound = jonathanMain.currentSoundHeard;
                jonathanMain.stateMachine.ChangeState(jonathanMain.investigateState);
                return;
            }
            else
            {
                jonathanMain.stateMachine.ChangeState(jonathanMain.patrolState);
                return;
            }
        }
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered Idle State");
        timer = 2f;
        jonathanMain.jonathanMovement.StopMovement();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        timer -= Time.deltaTime;
    }
}