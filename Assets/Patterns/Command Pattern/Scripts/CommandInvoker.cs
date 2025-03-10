using UnityEngine;
using System.Collections.Generic;


//Command Invoker, in charge of executing the commands and controling the Undo and Redo Stack.
public class CommandInvoker
{
    #region UNDO-REDO STACKS
    private static Stack<ICommand> _undoStack = new Stack<ICommand>();
    private static Stack<ICommand> _redoStack = new Stack<ICommand>();
    #endregion

    #region COMMAND METHODS
    public static void Execute(ICommand command) //Executes the commands and saves it to the undo stack
    {
        Debug.Log("Executing Command: " + command.GetType().ToString());
        command.Execute();
        _undoStack.Push(command);

        //Clean the redo stack because a new command is executed
        _redoStack.Clear();
    }

    public static void Undo() //Cheks the Undo Stack, selects the last added command, saves it to the redo stack and executes the undo command
    {
        if(_undoStack.Count > 0)
        {
            ICommand lastCommand = _undoStack.Pop(); //Pop deletes and returns last item on stack
            Debug.Log("UNDO Command: " + lastCommand.GetType().ToString());
            _redoStack.Push(lastCommand);
            lastCommand.Undo();
        }
    }

    public static void Redo() //Similar to Undo, Check redo stack, select last added command, saves it to the undo and executes the commands
    {
        if(_redoStack.Count > 0)
        {
            ICommand lastCommand = _redoStack.Pop();
            Debug.Log("REDO Command: " + lastCommand.GetType().ToString());
            _undoStack.Push(lastCommand);
            lastCommand.Execute();
        }
    }
    #endregion
}
