using UnityEngine;

public class JonathanRushState : JonathanState
{
    // What happens in this state:
    // Jonathan sprints to the position of the last heard noise past the freshold : Is running, faster than player running speed
    // If no noise is heard within a certain time after it reaches noise position, Switches to invetigate - 1-2 seconds

    public JonathanRushState(JonathanMain jonathanMain, StateMachine sm, Animator animationController, string animationName) : base(jonathanMain, sm, animationController, animationName)
    {
    }
    public override void TransitionChecks()
    {
        base.TransitionChecks();

        #region Safety Checks
        if (!jonathanMain.lockedSound.isValid) // Safety check to prevent bugs
        {
            jonathanMain.stateMachine.ChangeState(jonathanMain.investigateState);
            return;
        }
        #endregion

        // Check for new noise within and above freshold and update target position if necessary
        if (jonathanMain.currentSoundHeard.heardIntensity >= jonathanMain.pastNoiseThreshold)
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
            jonathanMain.lockedSound = default; // Clear locked sound to prevent bugs
            jonathanMain.stateMachine.ChangeState(jonathanMain.investigateState);
            return;
        }
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered Rush State");
        jonathanMain.jonathanMovement.SetToRun();
        jonathanMain.jonathanMovement.MoveTowardsTarget(jonathanMain.lockedSound.position);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        jonathanMain.jonathanMovement.MoveTowardsTarget(jonathanMain.lockedSound.position);
    }
}