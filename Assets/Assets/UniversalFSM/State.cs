using UnityEngine;

public class State
{
    #region Variables
    protected StateMachine sm;
    protected Animator animationController;
    protected string animationName;

    protected bool isExitingState;
    protected bool isAnimationFinished;
    protected float startTime;
    #endregion
    public State(StateMachine sm, Animator animationController, string animationName)
    {
        // Inheritance Values
        this.sm = sm;
        this.animationController = animationController;
        this.animationName = animationName;
    }
    public virtual void Enter()
    {
        isAnimationFinished = false;
        isExitingState = false;
        startTime = Time.time;
        //AnimationController.SetBool(AnimationName, true);   // Would be used for boolean based animations
    }
    public virtual void Exit()
    {
        isExitingState = true;
        if (!isAnimationFinished) isAnimationFinished = true;
        //AnimationController.SetBool(AnimationName, false);  // Would be used for boolean based animations
    }
    public virtual void LogicUpdate() // Called in the Update method of the MonoBehaviour that uses this StateMachine
    {
        if (isExitingState) return; // Prevents any logic update if we are exiting the state
        TransitionChecks(); // Remember when calling to call this first -> base.LogicUpdate();

        // And then do other things after - Not in here, in the override function
    }
    public virtual void PhysicsUpdate() // Called in the FixedUpdate method of the MonoBehaviour that uses this StateMachine
    {
    }
    public virtual void TransitionChecks() // Used to check for state transitions
    {

    }
    public virtual void SetAnimationTrigger()
    {
        isAnimationFinished = true;
    }
}