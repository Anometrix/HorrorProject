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
        if (jonathanMain.lockedSound.heardIntensity <= 0f) // Safety check to prevent bugs --------- BAD IN HERE
        {
            jonathanMain.stateMachine.ChangeState(jonathanMain.patrolState);
            return;
        }
        #endregion
        
        // Gotta add conditions to switch to idle or investigate AFTER reaching noise position
    }
    public override void Enter()
    {
        base.Enter();
        jonathanMain.jonathanMovement.SetToRun();
        jonathanMain.jonathanMovement.MoveTowardsTarget(jonathanMain.lockedSound.position);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        jonathanMain.jonathanMovement.MoveTowardsTarget(jonathanMain.lockedSound.position);
    }
}