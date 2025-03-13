using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private GameObject _pickupObject;
    [SerializeField] private GameObject _spawnPlane;
    [SerializeField] private float _maxObjects;

    private float _planeSize;

    [Header("Events")]
    public Event PickUpSpawned;

    #endregion

    #region UNITY METHODS
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       _planeSize = 5 * _spawnPlane.transform.localScale.x;
        SpawnPickups();
    }
    #endregion

    #region CUSTOM METHODS
    private void CreatePickup()
    {
        int xpos = (int)Random.Range(-_planeSize,_planeSize);
        int zpos = (int)Random.Range(-_planeSize, _planeSize);

        Vector3 pickUpPos = new Vector3(xpos, 0.5f, zpos);

        GameObject pickup = Instantiate(_pickupObject,pickUpPos,Quaternion.identity,transform);
        PickUpSpawned.Ocurred(pickup);
    }

    private void SpawnPickups()
    {
        for (int i = 0; i < _maxObjects; i++) 
        {
            CreatePickup();
        }
    }
    #endregion
}
