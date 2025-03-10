using UnityEngine;

public abstract class Command
{
    //A command can execute
    public abstract void Execute(Animator anim);
}


#region COMMANDS
public class PerformJump : Command
{
    public override void Execute(Animator anim)
    {
        Debug.Log("Command Execute: Jump");
        anim.SetTrigger("isJumping");
    }
}
public class PerformKick : Command
{
    public override void Execute(Animator anim)
    {
        Debug.Log("Command Execute: Kick");
        anim.SetTrigger("isKicking");
    }
}

public class PerformPunch : Command
{
    public override void Execute(Animator anim)
    {
        Debug.Log("Command Execute: Punch");
        anim.SetTrigger("isPunching");
    }
}

public class DoNothing : Command
{
    public override void Execute(Animator anim)
    {
        Debug.Log("Command Execute: Do Nothing");
    }
}
#endregion

