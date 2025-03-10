using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InputHandler : MonoBehaviour
{

    #region VARIABLES
    public GameObject actor;
    private Animator actorAnim;
    private Command keySpace,keyQ, keyW, keyE, upArrow;

    //Commands list
    private List<Command> oldCommands = new List<Command>();
    Coroutine replayCorutine;
    bool shouldStartReplay = false;
    bool isReplaying = false; 
    #endregion

    #region UNITY METHODS
    void Start()
    {
        keySpace = new PerformJump();
        keyQ = new PerformKick();
        keyE = new PerformPunch();

        upArrow = new MoveForward();

        actorAnim = actor.GetComponent<Animator>();

        //Apply camera follow to the selected actor in inspector
        Camera.main.GetComponent<CameraFollow360>().player = actor.transform;
    }

    void Update()
    {
        if (!isReplaying)
        {
            HandleInput();
        }
        StartReplay();
    }

    #region CUSTOM METHODS
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keySpace.Execute(actorAnim);
            oldCommands.Add(keySpace);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            keyQ.Execute(actorAnim);
            oldCommands.Add(keyQ);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            keyE.Execute(actorAnim);
            oldCommands.Add(keyE);
        }
        //Movement
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upArrow.Execute(actorAnim);
            oldCommands.Add(upArrow);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            shouldStartReplay = true; 
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            UndoLastCommand();
        }
    }

    private void StartReplay()
    {
        if(shouldStartReplay && oldCommands.Count > 0)
        {
            shouldStartReplay = false; 
            if(replayCorutine != null)
            {
                StopCoroutine(replayCorutine);
            }
            else
            {
                replayCorutine = StartCoroutine(ReplayCommands());
            }
        }
    }

    private void UndoLastCommand()
    {
        if(oldCommands.Count > 0)
        {
            Command c = oldCommands[oldCommands.Count - 1];
            c.Execute(actorAnim);
            oldCommands.RemoveAt(oldCommands.Count - 1);
        }
    }

    private IEnumerator ReplayCommands()
    {
        isReplaying = true; 
        for(int  i = 0; i < oldCommands.Count; i++)
        {
            oldCommands[i].Execute(actorAnim);
            yield return new WaitForSeconds(1f); //Idealy shoukd wait until animation is completed
        }
        isReplaying = false;
    }
    #endregion

    #endregion


}
