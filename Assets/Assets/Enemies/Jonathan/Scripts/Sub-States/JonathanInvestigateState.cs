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
}
