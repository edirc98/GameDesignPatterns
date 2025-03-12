using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _rows;
    [SerializeField] private float _cols;
    #endregion

    #region UNITY METHODS
    void Start()
    {
        SpawnCubes();
    }
    #endregion

    #region CUSTOM METHODS
    private void SpawnCubes()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                Vector3 pos = new Vector3(i
                                         , Mathf.PerlinNoise(i * 0.21f, j * 0.21f)
                                         , j);
                GameObject cube = Instantiate(_cubePrefab, pos, Quaternion.identity, transform);
            }
        }
    }
    #endregion

}
