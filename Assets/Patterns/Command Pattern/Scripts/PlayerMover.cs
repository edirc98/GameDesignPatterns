using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    #region VARIABLES
    public float moveAmount = 1.0f;
    #endregion

    #region CUSTOM METHODS
    public void Move(Vector3 direction)
    {
        transform.position += (direction * moveAmount);
    }
    #endregion
}
