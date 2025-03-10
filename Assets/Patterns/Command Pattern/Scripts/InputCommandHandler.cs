using UnityEngine;

public class InputCommandHandler : MonoBehaviour
{
    #region VARIABLES
    public GameObject PlayerActor;

    [SerializeField] private PlayerMover _playerMover; 
    #endregion

    #region UNITY METHODS
    private void Start()
    {
        _playerMover = PlayerActor.GetComponent<PlayerMover>();
    }
    #endregion

    #region CUSTOM METHODS
    private void RunMoveCommand(PlayerMover playerMover, Vector3 dir)
    {
        if (playerMover == null)
        {
            Debug.LogWarning("Player mover is null!");
            return;
        }
        else
        {
            ICommand newCommand = new MoveCommand(playerMover, dir);
            CommandInvoker.Execute(newCommand);
        }
    }
    #endregion

    #region EXPOSED FOR UI METHODS
    public void MoveUp()
    {
        RunMoveCommand(_playerMover, new Vector3(0.0f,0.0f,1.0f));
    }
    public void MoveDown()
    {
        RunMoveCommand(_playerMover, new Vector3(0.0f, 0.0f, -1.0f));
    }
    public void MoveRight()
    {
        RunMoveCommand(_playerMover, new Vector3(1.0f, 0.0f, 0.0f));
    }
    public void MoveLeft()
    {
        RunMoveCommand(_playerMover, new Vector3(-1.0f, 0.0f, 0.0f));
    }
    public void UndoMoveCommand()
    {
        CommandInvoker.Undo();
    }

    public void RedoMoveCommand()
    {
        CommandInvoker.Redo();
    }
    #endregion


}
