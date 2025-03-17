using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private List<GameObject> _pickupObjects;
    [SerializeField] private GameObject _spawnPlane;
    [SerializeField] private float _maxObjects;

    private float _planeSize;

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
        int pickupObject = (int)Random.Range(0, _pickupObjects.Count);
        int xpos = (int)Random.Range(-_planeSize, _planeSize);
        int zpos = (int)Random.Range(-_planeSize, _planeSize);

        Vector3 pickUpPos = new Vector3(xpos, 0.5f, zpos);

        GameObject pickup = Instantiate(_pickupObjects[pickupObject], pickUpPos,Quaternion.identity,transform);
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
