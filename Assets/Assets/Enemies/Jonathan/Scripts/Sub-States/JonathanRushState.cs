using UnityEngine;

public class JonathanRushState : JonathanState
{
    // What happens in this state:
    // Jonathan sprints to the position of the last heard noise past the freshold : Is running, faster than player running speed
    // If no noise is heard within a certain time after it reaches noise position, Switches to invetigate - 1-2 seconds

    public JonathanRushState(JonathanMain jonathanMain, StateMachine sm, Animator animationController, string animationName) : base(jonathanMain, sm, animationController, animationName)
    {
    }
}
