using UnityEngine;

public class JonathanPatrolState : JonathanState
{
    // What happens in this state:
    // Jonathan walks between set patrol points : Is walking, Faster than player
    // If a noise is heard within freshold, switches to investigate state.
    // if a noise is heard past freshold, switches to rush state.

    public JonathanPatrolState(JonathanMain jonathanMain, StateMachine sm, Animator animationController, string animationName) : base(jonathanMain, sm, animationController, animationName)
    {

    }
    public override void TransitionChecks()
    {
        base.TransitionChecks();

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
    }
    public override void Enter()
    {
        base.Enter();
        jonathanMain.jonathanMovement.SetToWalk();
        jonathanMain.jonathanMovement.Patrol();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        jonathanMain.jonathanMovement.Patrol();
    }
}