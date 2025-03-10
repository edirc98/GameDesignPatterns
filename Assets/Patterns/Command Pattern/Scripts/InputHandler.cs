using UnityEngine;

public class InputHandler : MonoBehaviour
{

    #region VARIABLES
    public GameObject actor;
    private Animator actorAnim;
    private Command keySpace,keyQ, keyW, keyE; 
    #endregion

    #region UNITY METHODS
    void Start()
    {
        keySpace = new PerformJump();
        keyQ = new PerformKick();
        keyW = new DoNothing();
        keyE = new PerformPunch();

        actorAnim = actor.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keySpace.Execute(actorAnim);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            keyQ.Execute(actorAnim);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            keyW.Execute(actorAnim);
        }
        else if (Input.GetKeyDown(KeyCode.E)){
            keyE.Execute(actorAnim);
        }
    }
    #endregion


}
