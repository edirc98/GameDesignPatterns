using UnityEngine;

public class MoveCommand : ICommand
{
    //Move Command contains the logic of the action performed by the comand
    //It should contain all neceary information to change game world and for restoring game world to prior state in case of undoing

    #region VARIABLES
    private PlayerMover _playerMover;
    private Vector3 _movementDirection;
    #endregion

    #region CONSTRUCTOR
    public MoveCommand(PlayerMover playerMover, Vector3 movementDirection) 
    {
        _playerMover = playerMover;
        _movementDirection = movementDirection; 
    }
    #endregion

    #region COMMAND METHODS
    public void Execute()
    {
        _playerMover.Move(_movementDirection);
    }
    public void Undo()
    {
        _playerMover.Move(-_movementDirection);
    }
    #endregion
}
