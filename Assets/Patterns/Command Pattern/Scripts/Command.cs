using UnityEngine;

public abstract class Command
{
    //A command can execute
    public abstract void Execute(Animator anim, bool forward);
}


#region COMMANDS
public class MoveForward : Command
{
    public override void Execute(Animator anim, bool forward)
    {
        if (forward)
        {
            Debug.Log("Command Execute: Move Forward");
            anim.SetTrigger("isWalking");
        }
        else
        {
            Debug.Log("Command Execute: Move Forward Reversed");
            anim.SetTrigger("isWalkingR");
        } 
    }
}
public class PerformJump : Command
{
    public override void Execute(Animator anim, bool forward)
    {
        if (forward)
        {
            Debug.Log("Command Execute: Jump");
            anim.SetTrigger("isJumping");
        }
        else
        {
            Debug.Log("Command Execute: Jump Reversed");
            anim.SetTrigger("isJumpingR");
        }
    }
}
public class PerformKick : Command
{
    public override void Execute(Animator anim, bool forward)
    {
        if (forward)
        {
            Debug.Log("Command Execute: Kick");
            anim.SetTrigger("isKicking");
        }
        else
        {
            Debug.Log("Command Execute: Kick Reversed");
            anim.SetTrigger("isKickingR");
        }
    }
}

public class PerformPunch : Command
{
    public override void Execute(Animator anim, bool forward)
    {
        if (forward)
        {
            Debug.Log("Command Execute: Punch");
            anim.SetTrigger("isPunching");
        }
        else
        {
            Debug.Log("Command Execute: Punch Reversed");
            anim.SetTrigger("isPunchingR");
        }
    }
}

public class DoNothing : Command
{
    public override void Execute(Animator anim, bool forward)
    {
        Debug.Log("Command Execute: Do Nothing");
    }
}
#endregion

