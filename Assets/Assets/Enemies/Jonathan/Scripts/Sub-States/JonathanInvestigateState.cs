using UnityEngine;

public class JonathanInvestigateState : JonathanState
{
    // What happens in this state:
    // Jonathan moves to the position of the last heard noise within the freshold : Is walking, Faster than player
    // If no noise is heard within a certain time after it reaches noise position, returns to patrol.
    // If a new noise is heard while investigating, updates target position to new noise position.
    // If Jonathan hears a sound past noise freshold while investigating, switches to rush state to noise position.

    public JonathanInvestigateState(JonathanMain jonathanMain, StateMachine sm, Animator animationController, string animationName) : base(jonathanMain, sm, animationController, animationName)
    {
    }
    public override void TransitionChecks()
    {
        base.TransitionChecks();

        #region Safety Checks
        if (!jonathanMain.lockedSound.isValid) // Safety check to prevent bugs
        {
            jonathanMain.stateMachine.ChangeState(jonathanMain.patrolState);
            return;
        }
        #endregion

        #region Change State Checks
        
        // Check for noise past freshold
        if (jonathanMain.currentSoundHeard.heardIntensity >= jonathanMain.pastNoiseThreshold)
        {
            jonathanMain.lockedSound = jonathanMain.currentSoundHeard;
            jonathanMain.stateMachine.ChangeState(jonathanMain.rushState);
            return;
        }

        // Check for new noise within freshold and update target position if necessary
        if (jonathanMain.currentSoundHeard.heardIntensity >= jonathanMain.withinNoiseThreshold)
        {
            if (jonathanMain.currentSoundHeard.heardIntensity > jonathanMain.lockedSound.heardIntensity + 2f)
            {
                jonathanMain.lockedSound = jonathanMain.currentSoundHeard;
            }
        }

        // Check for if target position has been reached
        float distanceToNoise = Vector3.Distance(jonathanMain.transform.position, jonathanMain.lockedSound.position);
        if (distanceToNoise <= 1f)
        {
            jonathanMain.stateMachine.ChangeState(jonathanMain.idleState);
            return;
        }
        #endregion
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered Investigate State");
        jonathanMain.jonathanMovement.SetToWalk();
        jonathanMain.jonathanMovement.MoveTowardsTarget(jonathanMain.lockedSound.position);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        jonathanMain.jonathanMovement.MoveTowardsTarget(jonathanMain.lockedSound.position);
    }
}