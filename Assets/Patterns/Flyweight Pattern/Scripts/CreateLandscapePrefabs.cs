using UnityEngine;

public class CreateLandscapePrefabs : MonoBehaviour
{
    #region VARIABLES
    [Header("Landscape Properties")]
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _width;
    [SerializeField] private int _depth;
    #endregion

    #region UNITY METHODS
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateLandscape();
    }
    #endregion


    #region CUSTOM METHODS
    public void GenerateLandscape()
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _depth; j++)
            {
                Vector3 pos = new Vector3(i
                                         ,Mathf.PerlinNoise(i * 0.2f, j * 0.2f) * 4
                                         ,j);
                GameObject cube = Instantiate(_cubePrefab, pos, Quaternion.identity, transform);
            }
        }
    }
    #endregion
}
