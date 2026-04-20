using UnityEngine;

public class JonathanState : State
{
    #region Variables -- Just one, really.
    protected JonathanMain jonathanMain;
    #endregion
    public JonathanState(JonathanMain jonathanMain, StateMachine sm, Animator animationController, string animationName) : base(sm,animationController,animationName)
    {
        this.jonathanMain = jonathanMain;
    }
}